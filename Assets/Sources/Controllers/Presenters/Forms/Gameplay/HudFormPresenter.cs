using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Presenters.Forms.Gameplay
{
    public class HudFormPresenter : PresenterBase
    {
        private readonly IHudFormView _view;
        private readonly IFormService _formService;

        public HudFormPresenter(
            IHudFormView view, 
            IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
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
            _formService.Show<PauseFormView>();
        }

        private void ShowUpgradeForm()
        {
            _formService.Show<UpgradeFormView>();
        }
    }
}