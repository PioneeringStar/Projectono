using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projectono.Environment
{
    public static class ObservableExtensions
    {
        public static void Bind<TSource, TSourceMember>(
            this TSource source,
            Expression<Func<TSource, TSourceMember>> sourceMember,
            Action<Observable.Notification> processor)
            where TSource : IObservable
        {
            var property = sourceMember.GetMember() as PropertyInfo;
            if (property == null) { throw new Exception("Observed member must be a property"); }
            source.Updated += (s, e) => {
                var notification = e.LastOrDefault(n => n.MemberName == property.Name);
                if (notification == null) { return; }
                processor(notification);
            };
        }

        public static void BindToTarget<TSource, TSourceMember, TTarget, TTargetMember>(
            this TSource source, 
            Expression<Func<TSource, TSourceMember>> sourceMember, 
            TTarget target,
            Expression<Func<TTarget, TTargetMember>> targetMember)
            where TTarget : IObservable
        {
            var targetProperty = targetMember.GetMember() as PropertyInfo;
            if (targetProperty == null) { throw new Exception("Observed member must be a property"); }
            var member = sourceMember.GetMember();
            var sourceProperty = member as PropertyInfo;
            var sourceField = member as FieldInfo;
            if (sourceProperty == null && sourceField == null) { throw new Exception("Observed member must be bound to a field or property"); }
            target.Bind(targetMember, n => {
                if (sourceProperty != null) { sourceProperty.SetValue(source, n.NewValue); }
                if (sourceField != null) { sourceField.SetValue(source, n.NewValue); }
            });
        }

        public static void BindToSource<TSource, TSourceMember, TTarget, TTargetMember>(
            this TSource source,
            Expression<Func<TSource, TSourceMember>> sourceMember,
            TTarget target,
            Expression<Func<TTarget, TTargetMember>> targetMember)
            where TSource : IObservable
        {
            BindToTarget(target, targetMember, source, sourceMember);
        }
    }
}
