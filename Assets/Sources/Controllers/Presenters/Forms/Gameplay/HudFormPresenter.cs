using System;
using JetBrains.Annotations;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class HudFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly IHudFormView _hudFormView;

        public HudFormPresenter(IFormService formService, IHudFormView hudFormView)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _hudFormView = hudFormView ?? throw new ArgumentNullException(nameof(hudFormView));
        }

        public override void Enable()
        {
            _hudFormView.PauseButtonView.AddClickListener(ShowPauseForm);
            _hudFormView.UpgradeButtonView.AddClickListener(ShowUpgradeForm);
        }

        public override void Disable()
        {
            _hudFormView.PauseButtonView.RemoveClickListener(ShowPauseForm);
            _hudFormView.UpgradeButtonView.RemoveClickListener(ShowUpgradeForm);
        }

        private void ShowPauseForm() =>
            _formService.Show<PauseFormView>();

        private void ShowUpgradeForm() =>
            _formService.Show<UpgradeFormView>();
    }
}