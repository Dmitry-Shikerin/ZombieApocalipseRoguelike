using System;
using Sources.Controllers.ModelViews.Forms.MainMenu;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.MainMenu
{
    public class MainMenuHudFormViewModelFactory : IViewModelFactory<MainMenuHudFormViewModel, MainMenuHudForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly NewGameViewModelComponentFactory _newGameViewModelComponentFactory;

        public MainMenuHudFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            NewGameViewModelComponentFactory newGameViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _newGameViewModelComponentFactory =
                newGameViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(newGameViewModelComponentFactory));
        }
        public IViewModel Create(MainMenuHudForm model)
        {
            return new MainMenuHudFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _newGameViewModelComponentFactory.Create(),
                });
        }
    }
}