using Sources.ControllersInterfaces.ViewModels;

namespace Sources.Frameworks.MVVM.InfrastructureInterfaces
{
    public interface IViewModelFactory<TViewModel, TModel> where TViewModel : IViewModel
    {
        IViewModel Create(TModel model);
    }
}