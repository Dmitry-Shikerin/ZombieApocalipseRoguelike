using Sources.ControllersInterfaces.ViewModels;
using Sources.Frameworks.PresentationInterfaces.Views;
using Sources.Frameworks.Presentations.Views;

namespace Sources.Frameworks.InfrastructureInterfaces
{
    public interface IBindableViewBuilder<TViewModel> 
        where TViewModel : IViewModel
    {
        IBindableView Build(int entityId,string viewPath, string prefabName,  IBindableView parent = null);
        public IBindableView Build(int entityId, BindableView bindableView, IBindableView parent = null);
    }
}