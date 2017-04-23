using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProjectOno.Environment
{
	public interface IObservable : INotifyPropertyChanged {

        /// <summary>
        /// Gets whether this observable is suspending notifications
        /// </summary>
        bool GetIsSuspended();

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
		event Observable.EventHandler Updated; // TODO: antipattern: We want to avoid imposing members on an observable. Perhaps we need "Add/Remove" methods for handlers
	}

	/// <summary>
	/// A base class for observable entities<br />
	/// Thread safe &amp; Concurrent<br />
	/// INotifyPropertyChanged compatable
	/// </summary>
	public abstract class Observable : IObservable
	{
        private readonly Publisher _publisher = new Publisher();

		bool IObservable.GetIsSuspended() { return _publisher.IsSuspended; }

		void IObservable.SuspendNotifications() { _publisher.IsSuspended = true; }

		void IObservable.ResumeNotifications() { _publisher.IsSuspended = false; }

		/// <summary>
		/// Retrieves the value for the calling member
		/// </summary>
		/// <returns>The value</returns>
		/// <param name="member">DO NOT SET</param>
		/// <typeparam name="TValue">Should match the member type being requested</typeparam>
		protected virtual TValue Get<TValue>([CallerMemberName]string member = null) { return _publisher.Get<TValue>(member); }

		/// <summary>
		/// Stores the value for the calling member and creates a notification
		/// </summary>
		/// <param name="value">The new value</param>
		/// <param name="member">DO NOT SET</param>
		/// <typeparam name="TValue">DO NOT SET</typeparam>
		protected virtual void Set<TValue>(TValue value, [CallerMemberName]string member = null) { _publisher.Set(member, value); }

		/// <summary>
		/// Sends or queues a notification based on the suspended state of this observable.
		/// </summary>
		/// <param name="notification">The notification to send or queue</param>
		protected virtual void OnNotification(Notification notification) { _publisher.OnNotification(notification); }

        /// <summary>
        /// Broadcasts notifications when a member's value has been set
        /// </summary>
		event EventHandler IObservable.Updated { add { _publisher.Updated += value; } remove { _publisher.Updated -= value; } }

        /// <summary>
        /// Broadcasts PropertyChangedEvents when a member's value has been set
        /// </summary>
		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _publisher.PropertyChanged += value; } remove { _publisher.PropertyChanged -= value; } }

		/// <summary>
		/// Provides information about an observation
		/// </summary>
		public class Notification {
            /// <summary>
            /// The member that was updated
            /// </summary>
			public string MemberName { get; private set; }
            /// <summary>
            /// The value prior to update
            /// </summary>
			public object OldValue { get; private set; }
            /// <summary>
            /// The new value of the member
            /// </summary>
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

        /// <summary>
        /// Internal backing class for managing observable values and notifications<br />
        /// Broken out for other base-classed objects
        /// </summary>
        public class Publisher
        {
            private readonly ConcurrentDictionary<string, object> _backing = new ConcurrentDictionary<string, object>();
            private readonly ConcurrentStack<Notification> _notificationQueue = new ConcurrentStack<Notification>();

            private bool _isSuspended = false;
            public bool IsSuspended {
                get { return _isSuspended; }
                set { if (!(_isSuspended = value)) SendNotifications(); }
            }

            public TValue Get<TValue>(string key) {
                return (TValue)_backing.GetOrAdd(key, default(TValue));
            }

            public void Set<TValue>(string key, TValue value) {
                var previous = Get<TValue>(key);
                _backing.AddOrUpdate(key, value, (k, v) => value);
                OnNotification(new Notification(key, previous, value));
            }

            public void OnNotification(Notification notification) {
                _notificationQueue.Push(notification);
                if (!_isSuspended) { SendNotifications(); }
            }

            private void SendNotifications()
            {
                var notifications = new Notification[_notificationQueue.Count];
                var count = _notificationQueue.TryPopRange(notifications);
                if (count == 0) { return; }
                notifications = notifications.Take(count).Reverse().ToArray();

                var updateHandler = Updated; // <--- for concurrency: do not "fix"
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

            public event PropertyChangedEventHandler PropertyChanged;
            public event EventHandler Updated;
        }
    }
}
