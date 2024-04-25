using System;
using Sources.Controllers.ModelViews.Forms.MainMenu;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.MainMenu
{
    public class WarningNewGameFormViewModelFactory : IViewModelFactory<WarningNewGameFormViewModel, WarningNewGameForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly ShowMainMenuHudFormViewModelComponentFactory _showMainMenuHudFormViewModelComponentFactory;
        private readonly ShowNewGameFormViewModelComponentFactory _showNewGameFormViewModelComponentFactory;

        public WarningNewGameFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            ShowMainMenuHudFormViewModelComponentFactory showMainMenuHudFormViewModelComponentFactory,
            ShowNewGameFormViewModelComponentFactory showNewGameFormViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _showMainMenuHudFormViewModelComponentFactory =
                showMainMenuHudFormViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(showMainMenuHudFormViewModelComponentFactory));
            _showNewGameFormViewModelComponentFactory = 
                showNewGameFormViewModelComponentFactory ?? 
                throw new ArgumentNullException(nameof(showNewGameFormViewModelComponentFactory));
        }
        public IViewModel Create(WarningNewGameForm model)
        {
            return new WarningNewGameFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _showMainMenuHudFormViewModelComponentFactory.Create(),
                    _showNewGameFormViewModelComponentFactory.Create(),
                });
        }
    }
}