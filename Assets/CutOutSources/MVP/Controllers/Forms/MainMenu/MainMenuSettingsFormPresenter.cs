using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Presenters.Forms.MainMenu
{
    public class MainMenuSettingsFormPresenter : PresenterBase
    {
        private readonly IMainMenuSettingsFormView _view;
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;

        public MainMenuSettingsFormPresenter(
            IMainMenuSettingsFormView view, 
            IMVPFormService imvpFormService,
            ILoadService loadService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }
        
        public override void Enable()
        {
            _view.MainMenuHudButtonView.AddClickListener(ShowMainMenuForm);
        }

        public override void Disable()
        {
            _view.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuForm);
        }

        private void ShowMainMenuForm()
        {
            _loadService.SaveAll();
            _imvpFormService.Show<MainMenuHudFormView>();
        }
    }
}