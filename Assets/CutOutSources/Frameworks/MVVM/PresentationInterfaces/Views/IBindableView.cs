using Sources.ControllersInterfaces.ViewModels;

namespace Sources.Frameworks.MVVM.PresentationInterfaces.Views
{
    public interface IBindableView
    {
        void Bind(IViewModel viewModel);
        void Unbind();
    }
}