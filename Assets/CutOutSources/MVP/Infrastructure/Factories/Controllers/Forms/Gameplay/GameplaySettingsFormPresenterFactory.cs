using System;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class GameplaySettingsFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;
        private readonly IPauseService _pauseService;

        public GameplaySettingsFormPresenterFactory(
            IMVPFormService imvpFormService,
            ILoadService loadService,
            IPauseService pauseService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public GameplaySettingsFormPresenter Create(IGameplaySettingsFormView view)
        {
            return new GameplaySettingsFormPresenter(
                view, 
                _imvpFormService, 
                _loadService,
                _pauseService);
        }
    }
}