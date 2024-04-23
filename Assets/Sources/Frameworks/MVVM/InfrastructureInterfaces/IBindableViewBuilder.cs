using Sources.ControllersInterfaces.ViewModels;
using Sources.Frameworks.PresentationInterfaces.Views;
using Sources.Frameworks.Presentations.Views;

namespace Sources.Frameworks.MVVM.InfrastructureInterfaces
{
    public interface IBindableViewBuilder<TViewModel, TModel> 
        where TViewModel : IViewModel
    {
        IBindableView Build(TModel model, string viewPath, string prefabName,  IBindableView parent = null);
        public IBindableView Build(TModel model, BindableView bindableView, IBindableView parent = null);
    }
}