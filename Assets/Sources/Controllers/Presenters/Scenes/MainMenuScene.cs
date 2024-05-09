using System;
using Cysharp.Threading.Tasks;
using Sources.ControllersInterfaces.Scenes;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.SdcInitializeServices;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Curtains;

namespace Sources.Controllers.Presenters.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly ILoadSceneService _loadSceneService;
        private readonly IVolumeService _volumeService;
        private readonly ILocalizationService _localizationService;
        private readonly ISdcInitializeService _sdcInitializeService;
        private readonly CurtainView _curtainView;

        public MainMenuScene(
            ILoadSceneService loadSceneService,
            IVolumeService volumeService,
            ILocalizationService localizationService,
            CurtainView curtainView,
            ISdcInitializeService sdcInitializeService)
        {
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _sdcInitializeService = sdcInitializeService ?? throw new ArgumentNullException(nameof(sdcInitializeService));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }
        
        public async void Enter(object payload = null)
        {
            await Initialize(payload as IScenePayload);
            _loadSceneService.Load(payload as IScenePayload);
            _localizationService.Translate();
            await _curtainView.HideCurtain();
            _volumeService.Enter();
        }

        public void Exit()
        {
            _volumeService.Exit();
        }

        public void Update(float deltaTime)
        {
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }

        private async UniTask Initialize(IScenePayload payload)
        {
            if (payload.CanFromGameplay)
                 return;
            
            _sdcInitializeService.EnableCallbackLogging();
            await _sdcInitializeService.Initialize();
        }
    }
}