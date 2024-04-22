using Sources.ControllersInterfaces.ViewModels;

namespace Sources.Frameworks.InfrastructureInterfaces
{
    public interface IViewModelFactory<TViewModel> where TViewModel : IViewModel
    {
        IViewModel Create(int id);
    }
}