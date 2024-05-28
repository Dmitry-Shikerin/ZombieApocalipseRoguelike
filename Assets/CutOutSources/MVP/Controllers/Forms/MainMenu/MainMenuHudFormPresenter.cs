using System;
using Sources.Domain.Models.Data.Ids;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Presenters.Forms.MainMenu
{
    public class MainMenuHudFormPresenter : PresenterBase
    {
        private readonly IMainMenuHudFormView _view;
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;

        public MainMenuHudFormPresenter(
            IMainMenuHudFormView view,
            IMVPFormService imvpFormService,
            ILoadService loadService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public override void Enable()
        {
            if (_loadService.HasKey(ModelId.PlayerWallet) == false)
                _view.LoadGameButtonView.Hide();
            else
                _view.LoadGameButtonView.Show();
            
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
            _imvpFormService.Show<LeaderboardFormView>();
        }

        private void ShowSettingsForm()
        {
            _imvpFormService.Show<MainMenuSettingsFormView>();
        }

        private void LoadSavedGame()
        {
        }

        private void ShowNewGameForm()
        {
            if (_loadService.HasKey(ModelId.PlayerWallet))
            {
                _imvpFormService.Show<WarningNewGameFormView>();

                return;
            }

            _imvpFormService.Show<NewGameFormView>();
        }
    }
}