using System;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Common.Forms.MainMenu
{
    public class MainMenuHudFormPresenter : PresenterBase
    {
        private readonly IMainMenuHudFormView _view;
        private readonly IFormService _formService;

        public MainMenuHudFormPresenter(
            IMainMenuHudFormView view, 
            IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _view.LeaderBoardButtonView.AddClickListener(ShowLeaderboardForm);
            _view.SettingsButtonView.AddClickListener(ShowSettingsForm);
            _view.LoadGameButtonView.AddClickListener(LoadSavedGame);
            _view.NewGameButtonView.AddClickListener(ShowNewGameForm);
        }

        public override void Disable()
        {
            _view.LeaderBoardButtonView.RemoveClickListener(ShowLeaderboardForm);
            _view.SettingsButtonView.RemoveClickListener(ShowSettingsForm);
            _view.LoadGameButtonView.RemoveClickListener(LoadSavedGame);
            _view.NewGameButtonView.RemoveClickListener(ShowNewGameForm);
        }

        private void ShowLeaderboardForm()
        {
            _formService.Show<LeaderboardFormView>();
        }

        private void ShowSettingsForm()
        {
            _formService.Show<MainMenuSettingsFormView>();
        }

        private void LoadSavedGame()
        {
        }

        private void ShowNewGameForm()
        {
            
        }
    }
}