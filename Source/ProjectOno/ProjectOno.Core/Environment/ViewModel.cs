
namespace ProjectOno.Environment
{
    public interface IViewModel : IObservable
    {
        IViewModel Parent { get; }
    }

    public abstract class ViewModel : Observable, IViewModel
    {
        private IIocContainer _container;
        private IViewModel _parent;
        IViewModel IViewModel.Parent { get { return _parent; } }

        protected abstract void OnReady();

        public TViewModel CreateChild<TViewModel>()
            where TViewModel : ViewModel
        {
            var viewmodel = (TViewModel)_container.Resolve(typeof(TViewModel));
            Factory.Configure(viewmodel, _container, this);
            return viewmodel;
        }

        public void AddChild(ViewModel viewmodel)
        {
            Factory.Configure(viewmodel, _container, this);
        }

        public static class Factory
        {
            public static void Configure(ViewModel viewmodel, IIocContainer container, IViewModel parent)
            {
                var scope = container.CreateScope();
                scope.AddInstance(typeof(IViewModel), viewmodel);
                viewmodel._container = scope;
                viewmodel._parent = parent;
                viewmodel.OnReady();
            }
        }
    }
}
