
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
            return Factory.Create<TViewModel>(_container, this);
        }

        public static class Factory
        {
            public static TViewModel Create<TViewModel>(IIocContainer container, IViewModel parent)
                where TViewModel : ViewModel
            {
                var viewmodel = (TViewModel)container.Resolve(typeof(TViewModel));
                viewmodel._parent = parent;
                var scope = container.CreateScope();
                scope.AddInstance(typeof(IViewModel), viewmodel);
                viewmodel._container = scope;
                viewmodel.OnReady();
                return viewmodel;
            }
        }
    }
}
