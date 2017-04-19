using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProjectOno.Core.Environment
{
	public interface IObservable : INotifyPropertyChanged {

		/// <summary>
		/// Gets whether this observable is suspending notifications
		/// </summary>
		bool IsSuspendingNotifications { get; }

		/// <summary>
		/// Suspends observation notifications.
		/// </summary>
		void SuspendNotifications();

		/// <summary>
		/// Resumes observation notifications.
		/// </summary>
		void ResumeNotifications();

		/// <summary>
		/// Fired when an observation notification is available
		/// </summary>
		event Observable.EventHandler Updated;
	}

	/// <summary>
	/// A base class for observable entities<br />
	/// Thread safe &amp; Concurrent<br />
	/// INotifyPropertyChanged compatable
	/// </summary>
	public abstract class Observable : IObservable
	{
		private readonly ConcurrentDictionary<string, object> _backing = new ConcurrentDictionary<string, object>();
		private readonly ConcurrentStack<Notification> _notificationQueue = new ConcurrentStack<Notification>();

		private bool _suspended;
		bool IObservable.IsSuspendingNotifications { get { return _suspended; } }

		void IObservable.SuspendNotifications() { _suspended = true; }

		void IObservable.ResumeNotifications() {
			_suspended = false;
			SendNotifications();
		}

		/// <summary>
		/// Retrieves the value for the calling member
		/// </summary>
		/// <returns>The value</returns>
		/// <param name="member">DO NOT SET</param>
		/// <typeparam name="TValue">Should match the member type being requested</typeparam>
		protected virtual TValue Get<TValue>([CallerMemberName]string member = null) {
			return (TValue)_backing.GetOrAdd(member, m => default(TValue));
		}

		/// <summary>
		/// Stores the value for the calling member and creates a notification
		/// </summary>
		/// <param name="value">The new value</param>
		/// <param name="member">DO NOT SET</param>
		/// <typeparam name="TValue">DO NOT SET</typeparam>
		protected virtual void Set<TValue>(TValue value, [CallerMemberName]string member = null) {
			var previous = Get<TValue>(member);
			_backing.AddOrUpdate(member, value, (m, v) => value);
			OnNotification(new Notification(member, previous, value));
		}

		/// <summary>
		/// Sends or queues a notification based on the suspended state of this observable.
		/// </summary>
		/// <param name="notification">The notification to send or queue</param>
		protected virtual void OnNotification(Notification notification) {
			_notificationQueue.Push(notification);
			if (!((IObservable)this).IsSuspendingNotifications) { SendNotifications(); }
		}

		private void SendNotifications() {
			var notifications = new Notification[_notificationQueue.Count];
			var count = _notificationQueue.TryPopRange(notifications);
			if (count == 0) { return; }
			notifications = notifications.Take(count).Reverse().ToArray();

			var updateHandler = Updated;
			if (updateHandler != null) { updateHandler(this, new EventArgs(notifications)); }
			var changedHandler = PropertyChanged;
			if (changedHandler != null) {
				var events = notifications
					.Select(n => n.MemberName)
					.Distinct()
					.Select(n => new PropertyChangedEventArgs(n))
					.ToArray();
				foreach (var evt in events) {
					changedHandler(this, evt);
				}
			}
		}

		private event EventHandler Updated;
		event EventHandler IObservable.Updated {
			add { this.Updated += value; }
			remove { this.Updated -= value; }
		}

		private event PropertyChangedEventHandler PropertyChanged;
		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { 
			add { this.PropertyChanged += value; }
			remove { this.PropertyChanged -= value; }
		}

		/// <summary>
		/// Provides information about an observation
		/// </summary>
		public class Notification {
			public string MemberName { get; private set; }
			public object OldValue { get; private set; }
			public object NewValue { get; private set; }
			public Notification(string member, object oldValue, object newValue) {
				MemberName = member;
				OldValue = oldValue;
				NewValue = newValue;
			}
		}

		/// <summary>
		/// Provides information about an Observable Updated event
		/// </summary>
		public class EventArgs : System.EventArgs, IEnumerable<Notification> {
			private readonly IEnumerable<Notification> _notifications;
			public EventArgs(IEnumerable<Notification> notifications) { _notifications = notifications.ToArray(); }
			IEnumerator IEnumerable.GetEnumerator() { return _notifications.GetEnumerator(); }
			IEnumerator<Notification> IEnumerable<Notification>.GetEnumerator() { return _notifications.GetEnumerator(); }
		}

		/// <summary>
		/// Handler for providing information about Observable updates.
		/// </summary>
		public delegate void EventHandler(object sender, EventArgs e);
	}
}
