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
        private readonly ShowWarningNewGameFormViewModelComponentFactory _showWarningNewGameFormViewModelComponentFactory;
        private readonly LoadGameViewModelComponentFactory _loadGameViewModelComponentFactory;
        private readonly ShowLeaderboardFormViewModelComponentFactory _showLeaderboardFormViewModelComponentFactory;
        private readonly ShowMainMenuSettingsFormViewModelComponentFactory _showMainMenuSettingsFormViewModelComponentFactory;
        private readonly TryShowNewGameFormViewModelComponentFactory _tryShowNewGameFormViewModelComponentFactory;

        public MainMenuHudFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            ShowWarningNewGameFormViewModelComponentFactory showWarningNewGameFormViewModelComponentFactory,
            LoadGameViewModelComponentFactory loadGameViewModelComponentFactory,
            ShowLeaderboardFormViewModelComponentFactory showLeaderboardFormViewModelComponentFactory,
            ShowMainMenuSettingsFormViewModelComponentFactory showMainMenuSettingsFormViewModelComponentFactory,
            TryShowNewGameFormViewModelComponentFactory tryShowNewGameFormViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _showWarningNewGameFormViewModelComponentFactory =
                showWarningNewGameFormViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(showWarningNewGameFormViewModelComponentFactory));
            _loadGameViewModelComponentFactory = loadGameViewModelComponentFactory ?? throw new ArgumentNullException(nameof(loadGameViewModelComponentFactory));
            _showLeaderboardFormViewModelComponentFactory = showLeaderboardFormViewModelComponentFactory ?? throw new ArgumentNullException(nameof(showLeaderboardFormViewModelComponentFactory));
            _showMainMenuSettingsFormViewModelComponentFactory = showMainMenuSettingsFormViewModelComponentFactory ?? throw new ArgumentNullException(nameof(showMainMenuSettingsFormViewModelComponentFactory));
            _tryShowNewGameFormViewModelComponentFactory =
                tryShowNewGameFormViewModelComponentFactory ?? 
                throw new ArgumentNullException(nameof(tryShowNewGameFormViewModelComponentFactory));
        }
        public IViewModel Create(MainMenuHudForm model)
        {
            return new MainMenuHudFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _loadGameViewModelComponentFactory.Create(),
                    // _showWarningNewGameFormViewModelComponentFactory.Create(),
                    _tryShowNewGameFormViewModelComponentFactory.Create(),
                    _showLeaderboardFormViewModelComponentFactory.Create(),
                    _showMainMenuSettingsFormViewModelComponentFactory.Create(),
                });
        }
    }
}