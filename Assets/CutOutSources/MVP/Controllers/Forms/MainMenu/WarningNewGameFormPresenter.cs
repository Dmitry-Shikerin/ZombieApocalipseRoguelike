using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Controllers.Presenters.Forms.MainMenu
{
    public class WarningNewGameFormPresenter : PresenterBase
    {
        private readonly IWarningNewGameFormView _view;
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;

        public WarningNewGameFormPresenter(
            IWarningNewGameFormView view, 
            IMVPFormService imvpFormService,
            ILoadService loadService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public override void Enable()
        {
            _view.NewGameButtonView.AddClickListener(ShowNewGameForm);
            _view.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);
        }

        public override void Disable()
        {
            _view.NewGameButtonView.RemoveClickListener(ShowNewGameForm);
            _view.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);
        }

        private void ShowNewGameForm()
        {
            _loadService.ClearAll();
            _imvpFormService.Show<NewGameFormView>();
        }

        private void ShowMainMenuHudForm()
        {
            _imvpFormService.Show<MainMenuHudFormView>();
        }
    }
}