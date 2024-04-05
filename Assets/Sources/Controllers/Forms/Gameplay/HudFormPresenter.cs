using System;
using Assets.Sources.InfastructureInterfaces.Services.Forms;
using JetBrains.Annotations;
using Sources.Controllers.Common;
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

        public override void Enable() =>
            _hudFormView.PauseButtonView.AddClickListener(ShowPauseForm);

        public override void Disable() =>
            _hudFormView.PauseButtonView.RemoveClickListener(ShowPauseForm);

        private void ShowPauseForm() =>
            _formService.Show<PauseFormView>();
    }
}