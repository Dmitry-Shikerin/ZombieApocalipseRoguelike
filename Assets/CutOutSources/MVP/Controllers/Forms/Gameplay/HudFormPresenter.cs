using System;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Presenters.Forms.Gameplay
{
    public class HudFormPresenter : PresenterBase
    {
        private readonly IHudFormView _view;
        private readonly IMVPFormService _imvpFormService;

        public HudFormPresenter(
            IHudFormView view, 
            IMVPFormService imvpFormService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public override void Enable()
        {
            _view.PauseButtonView.AddClickListener(ShowPauseForm);
            _view.UpgradeButtonView.AddClickListener(ShowUpgradeForm);
        }

        public override void Disable()
        {
            _view.PauseButtonView.RemoveClickListener(ShowPauseForm);
            _view.UpgradeButtonView.RemoveClickListener(ShowUpgradeForm);
        }

        private void ShowPauseForm()
        {
            _imvpFormService.Show<PauseFormView>();
        }

        private void ShowUpgradeForm()
        {
            _imvpFormService.Show<UpgradeFormView>();
        }
    }
}