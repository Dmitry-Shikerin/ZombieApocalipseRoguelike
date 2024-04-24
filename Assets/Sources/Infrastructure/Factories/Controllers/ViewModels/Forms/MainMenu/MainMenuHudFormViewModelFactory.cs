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
        private readonly LoadGameViewModelComponentFactory _loadGameViewModelComponentFactory;
        private readonly ShowLeaderboardFormViewModelComponentFactory _showLeaderboardFormViewModelComponentFactory;
        private readonly ShowMainMenuSettingsFormViewModelComponentFactory _showMainMenuSettingsFormViewModelComponentFactory;

        public MainMenuHudFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            NewGameViewModelComponentFactory newGameViewModelComponentFactory,
            LoadGameViewModelComponentFactory loadGameViewModelComponentFactory,
            ShowLeaderboardFormViewModelComponentFactory showLeaderboardFormViewModelComponentFactory,
            ShowMainMenuSettingsFormViewModelComponentFactory showMainMenuSettingsFormViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _newGameViewModelComponentFactory =
                newGameViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(newGameViewModelComponentFactory));
            _loadGameViewModelComponentFactory = loadGameViewModelComponentFactory ?? throw new ArgumentNullException(nameof(loadGameViewModelComponentFactory));
            _showLeaderboardFormViewModelComponentFactory = showLeaderboardFormViewModelComponentFactory ?? throw new ArgumentNullException(nameof(showLeaderboardFormViewModelComponentFactory));
            _showMainMenuSettingsFormViewModelComponentFactory = showMainMenuSettingsFormViewModelComponentFactory ?? throw new ArgumentNullException(nameof(showMainMenuSettingsFormViewModelComponentFactory));
        }
        public IViewModel Create(MainMenuHudForm model)
        {
            return new MainMenuHudFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _newGameViewModelComponentFactory.Create(),
                    _loadGameViewModelComponentFactory.Create(),
                    _showLeaderboardFormViewModelComponentFactory.Create(),
                    _showMainMenuSettingsFormViewModelComponentFactory.Create(),
                });
        }
    }
}