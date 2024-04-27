using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Data.Ids;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Presenters.Forms.Gameplay
{
    public class GameplaySettingsFormPresenter : PresenterBase
    {
        private readonly IGameplaySettingsFormView _view;
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;
        private readonly IPauseService _pauseService;

        public GameplaySettingsFormPresenter(
            IGameplaySettingsFormView view, 
            IMVPFormService imvpFormService,
            ILoadService loadService,
            IPauseService pauseService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public override void Enable()
        {
            _pauseService.Pause();
            _view.PauseFormButtonView.AddClickListener(ShowPauseForm);
        }

        public override void Disable()
        {
            _pauseService.Continue();
            _view.PauseFormButtonView.RemoveClickListener(ShowPauseForm);
        }

        private void ShowPauseForm()
        {
            //TODO удобно тем что в разных местах нужно разное сохранять
            _loadService.Save(ModelId.Volume);
            _imvpFormService.Show<PauseFormView>();
        }
    }
}