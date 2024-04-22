using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class UpgradeFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly IUpgradeFormView _upgradeFormView;

        public UpgradeFormPresenter(IFormService formService, IUpgradeFormView upgradeFormView)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _upgradeFormView = upgradeFormView ?? throw new ArgumentNullException(nameof(upgradeFormView));
        }
        
        public override void Enable() =>
            _upgradeFormView.HudButtonView.AddClickListener(ShowHudForm);

        public override void Disable() =>
            _upgradeFormView.HudButtonView.RemoveClickListener(ShowHudForm);

        private void ShowHudForm() =>
            _formService.Show<HudFormView>();
    }
}