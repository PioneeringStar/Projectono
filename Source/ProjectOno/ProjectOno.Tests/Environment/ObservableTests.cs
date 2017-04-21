using NUnit.Framework;
using ProjectOno.Environment;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProjectOno.Tests.Environment
{
    [TestFixture]
    public class ObservableTests
    {
        [Test]
        public void CanCreate()
        {
            Assert.NotNull(new TestObservable());
        }

        [Test]
        public void CanReadAndWrite()
        {
            var test = new TestObservable();
            test.PropertyA = 10;
            Assert.AreEqual(10, test.PropertyA);
        }

        [Test]
        public void HasDefaultValue()
        {
            var test = new TestObservable();
            Assert.AreEqual(default(int), test.PropertyA);
        }

        [Test]
        public void CanNotifyPropertyChanged()
        {
            var test = new TestObservable();
            var member = "";
            var count = 0;
            ((INotifyPropertyChanged)test).PropertyChanged += (s, e) => {
                count++;
                member = e.PropertyName;
            };
            test.PropertyA = 10;

            Assert.AreEqual(1, count);
            Assert.AreEqual("PropertyA", member);
        }

        [Test]
        public void CanNotifyUpdate()
        {
            var test = new TestObservable();
            var notifications = new List<Observable.Notification>();
            ((IObservable)test).Updated += (s, e) => {
                notifications.AddRange(e);
            };
            test.PropertyA = 10;

            Assert.AreEqual(1, notifications.Count);
            Assert.AreEqual("PropertyA", notifications[0].MemberName);
            Assert.AreEqual(0, notifications[0].OldValue);
            Assert.AreEqual(10, notifications[0].NewValue);
        }

        [Test]
        public void CanSuspendNotifications()
        {
            var test = new TestObservable();
            var propertyChanges = new List<string>();
            var observations = new List<Observable.Notification>();

            ((INotifyPropertyChanged)test).PropertyChanged += (s, e) => { propertyChanges.Add(e.PropertyName); };
            ((IObservable)test).Updated += (s, e) => { observations.AddRange(e); };
            ((IObservable)test).SuspendNotifications();
            test.PropertyA = 10;

            Assert.AreEqual(true, ((IObservable)test).IsSuspendingNotifications);
            Assert.AreEqual(0, propertyChanges.Count);
            Assert.AreEqual(0, observations.Count);
        }

        [Test]
        public void CanResumeNotifications()
        {
            var test = new TestObservable();
            var propertyChanges = new List<string>();
            var observations = new List<Observable.Notification>();

            ((INotifyPropertyChanged)test).PropertyChanged += (s, e) => { propertyChanges.Add(e.PropertyName); };
            ((IObservable)test).Updated += (s, e) => { observations.AddRange(e); };
            ((IObservable)test).SuspendNotifications();
            test.PropertyA = 10;
            test.PropertyA = 20;
            test.PropertyB = 30;
            ((IObservable)test).ResumeNotifications();

            Assert.AreEqual(false, ((IObservable)test).IsSuspendingNotifications);
            Assert.AreEqual(2, propertyChanges.Count);
            Assert.AreEqual("PropertyA", propertyChanges[0]);
            Assert.AreEqual("PropertyB", propertyChanges[1]);
            Assert.AreEqual(3, observations.Count);
            Assert.AreEqual("PropertyA", observations[0].MemberName);
            Assert.AreEqual(0, observations[0].OldValue);
            Assert.AreEqual(10, observations[0].NewValue);
            Assert.AreEqual("PropertyA", observations[1].MemberName);
            Assert.AreEqual(10, observations[1].OldValue);
            Assert.AreEqual(20, observations[1].NewValue);
            Assert.AreEqual("PropertyB", observations[2].MemberName);
            Assert.AreEqual(0, observations[2].OldValue);
            Assert.AreEqual(30, observations[2].NewValue);
        }

        private class TestObservable : Observable
        {
            public int PropertyA { get { return Get<int>(); } set { Set(value); } }
            public int PropertyB { get { return Get<int>(); } set { Set(value); } }
        }
    }
}
