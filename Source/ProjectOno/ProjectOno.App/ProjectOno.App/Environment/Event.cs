using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectOno.App.Environment
{
    public class Event : BindableObject
    {
        public static readonly BindableProperty BindProperty = BindableProperty.CreateAttached(
            "Bind",
            typeof(string),
            typeof(Event),
            null,
            BindingMode.OneWay,
            null,
            OnBind
        );

        public static void SetBind(BindableObject target, string value) { target.SetValue(BindProperty, value); }

        public static string GetBind(BindableObject target) { return (string)target.GetValue(BindProperty); }

        private static void OnBind(BindableObject source, object oldValue, object newValue)
        {
            var value = newValue as string;
            if (value == null) { return; }
            var parsed = Regex.Match(value, @"^([^\s]+?)\s*->\s*([^\s]+?)$");
            if (parsed == null) { throw new Exception("Event.Bind format: \"Event -> Handler\""); }
            var parts = parsed.Groups.OfType<Group>().Skip(1).Select(g => g.Value).ToArray();
            if (parts.Length != 2) { throw new Exception("Event.Bind format: \"Event -> Handler\""); }

            object sourceObject = null; MemberInfo sourceMember = null;
            if (!TryGetMember(source, parts[0], out sourceObject, out sourceMember)) {
                throw new Exception("Event binding source not found: " + value);
            }
            var sourceEvent = sourceMember as EventInfo;
            if (sourceEvent == null) { throw new Exception("Source member must be an event: " + value); }
            SetBinding(sourceObject, sourceEvent, source, parts[1]);
        }

        private static bool TryGetMember(object source, string member, out object target, out MemberInfo info)
        {
            target = null; info = null;
            if (string.IsNullOrWhiteSpace(member) || source == null) { return false; }
            target = source;
            var path = member.Split(".".ToCharArray());
            for (var i = 0; i < path.Length - 2 && target != null; i++) {
                info = target.GetType().GetTypeInfo().DeclaredMembers.FirstOrDefault(m => m.Name == path[i]);
                if (info is PropertyInfo) { target = ((PropertyInfo)info).GetValue(target); } else if (info is FieldInfo) { target = ((FieldInfo)info).GetValue(target); } else { return false; }
            }
            if (target == null) { return false; }
            info = target.GetType().GetTypeInfo().DeclaredMembers.FirstOrDefault(m => m.Name == path.Last());
            return info != null;
        }

        private static void SetBinding(object source, EventInfo sourceEvent, BindableObject target, string targetPath)
        {
            var handler = new Action<object, EventArgs>((sender, e) => {
                object methodSource = null; MemberInfo methodMember = null;
                if (!TryGetMember(target.BindingContext, targetPath, out methodSource, out methodMember)) {
                    return;
                }
                var method = methodMember as MethodInfo;
                if (method == null) { throw new Exception("Event must be bound to a method: " + targetPath); }
                var hdlParams = method.GetParameters();
                var hasLength = hdlParams.Length == 2;
                var hasSender = hdlParams[0].ParameterType == typeof(object);
                var hasArgs = e == null || hdlParams[1].ParameterType.GetTypeInfo().IsAssignableFrom(e.GetType().GetTypeInfo());
                if (!hasLength || !hasSender || !hasArgs) {
                    throw new Exception("Target method signature incompatible with event: " + targetPath);
                }
                method.Invoke(methodSource, new object[] { sender, e });
            });
            var handlerMethod = handler.GetType().GetMethod("Invoke");
            var dlg = Delegate.CreateDelegate(sourceEvent.EventHandlerType, handler, handlerMethod);
            sourceEvent.AddEventHandler(source, dlg);
        }
    }
}
