using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class UpgradeFormPresenter : PresenterBase
    {
        private readonly IViewFormService _viewFormService;
        private readonly IUpgradeFormView _upgradeFormView;

        public UpgradeFormPresenter(IViewFormService viewFormService, IUpgradeFormView upgradeFormView)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
            _upgradeFormView = upgradeFormView ?? throw new ArgumentNullException(nameof(upgradeFormView));
        }
        
        public override void Enable() =>
            _upgradeFormView.HudButtonView.AddClickListener(ShowHudForm);

        public override void Disable() =>
            _upgradeFormView.HudButtonView.RemoveClickListener(ShowHudForm);

        private void ShowHudForm() =>
            _viewFormService.Show<HudFormView>();
    }
}