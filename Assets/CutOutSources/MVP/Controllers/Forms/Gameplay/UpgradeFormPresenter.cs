using System;
using Sources.Controllers.Presenters;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Common.Forms
{
    public class UpgradeFormPresenter : PresenterBase
    {
        private readonly IUpgradeFormView _view;
        private readonly IMVPFormService _imvpFormService;

        public UpgradeFormPresenter(
            IUpgradeFormView view, 
            IMVPFormService imvpFormService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public override void Enable()
        {
            _view.HudButtonView.AddClickListener(ShowHudForm);
        }

        public override void Disable()
        {
            _view.HudButtonView.RemoveClickListener(ShowHudForm);
        }

        private void ShowHudForm()
        {
            _imvpFormService.Show<HudFormView>();
        }
    }
}