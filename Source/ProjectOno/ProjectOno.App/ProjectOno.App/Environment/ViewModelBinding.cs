using ProjectOno.Environment;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace ProjectOno.App.Environment
{
    [ContentProperty("Path")]
    public class ViewModelBinding : IMarkupExtension
    {
        public string Path { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var target = ((IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget))).TargetObject as VisualElement;
            if (target == null) throw new Exception("ViewModelBindings must be added to a VisualElement in the VisualTree");

            var binding = new Binding {
                Path = Path,
                Mode = BindingMode.OneWay,
                Converter = new ViewProvider(target)
            };
            return binding;
        }

        private class ViewProvider : IValueConverter
        {
            private readonly VisualElement ViewContext;

            public ViewProvider(VisualElement context) { ViewContext = context; }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var viewmodel = value as IViewModel;
                if (viewmodel == null) return null;
                var viewmodelType = viewmodel.GetType().GetTypeInfo();

                var template = SearchContext(ViewContext, context => {
                    if (context == null) { return null; }
                    var match = context.Values
                        .OfType<ViewModelTemplate>()
                        .LastOrDefault(t => viewmodelType.IsAssignableFrom(t.ViewModelType.GetTypeInfo()));
                    return match;
                });

                if (template == null) { throw new Exception("View not found for ViewModel: " + viewmodelType.AsType().ToString()); }

                return CreateContent(template, viewmodel);
            }

            private object CreateContent(ViewModelTemplate template, IViewModel viewmodel)
            {
                if (template.ControlTemplate == null) { return null; }
                try {
                    var content = template.ControlTemplate.CreateContent() as BindableObject;
                    if (content == null) { throw new Exception("ViewModelTemplates must deliver a BindableObject"); }
                    content.BindingContext = viewmodel;
                    return content;
                } catch (Exception e) {
                    throw e;
                }
            }

            private ViewModelTemplate SearchContext(VisualElement source, Func<ResourceDictionary, ViewModelTemplate> searcher)
            {
                while (source != null) {
                    var match = searcher(source.Resources);
                    if (match != null) { return match; }
                    var parent = source.Parent;
                    while (parent != null && !(parent is VisualElement)) {
                        parent = parent.Parent;
                    }
                    source = parent as VisualElement;
                }
                return searcher(Xamarin.Forms.Application.Current.Resources);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    }
}
