using System;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Common.Forms
{
    public class UpgradeFormPresenter : PresenterBase
    {
        private readonly IUpgradeFormView _view;
        private readonly IFormService _formService;

        public UpgradeFormPresenter(
            IUpgradeFormView view, 
            IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
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
            _formService.Show<HudFormView>();
        }
    }
}