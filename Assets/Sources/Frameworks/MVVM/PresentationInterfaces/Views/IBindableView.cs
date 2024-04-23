using Sources.ControllersInterfaces.ViewModels;

namespace Sources.Frameworks.PresentationInterfaces.Views
{
    public interface IBindableView
    {
        void Bind(IViewModel viewModel);
        void Unbind();
    }
}