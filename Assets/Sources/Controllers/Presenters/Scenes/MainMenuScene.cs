using System;
using Cysharp.Threading.Tasks;
using Sources.ControllersInterfaces.Scenes;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.ServicesInterfaces.AudioSources;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Frameworks.YandexSdcFramework.Services.Stickies;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.Focuses;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.SdcInitializeServices;
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
        private readonly IStickyService _stickyService;
        private readonly IAudioService _audioService;
        private readonly IFocusService _focusService;
        private readonly CurtainView _curtainView;

        public MainMenuScene(
            ILoadSceneService loadSceneService,
            IVolumeService volumeService,
            ILocalizationService localizationService,
            CurtainView curtainView,
            ISdcInitializeService sdcInitializeService,
            IStickyService stickyService,
            IAudioService audioService,
            IFocusService focusService)
        {
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _sdcInitializeService = sdcInitializeService ?? throw new ArgumentNullException(nameof(sdcInitializeService));
            _stickyService = stickyService ?? throw new ArgumentNullException(nameof(stickyService));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }
        
        public async void Enter(object payload = null)
        {
            await Initialize(payload as IScenePayload);
            _focusService.Enable();
            _loadSceneService.Load(payload as IScenePayload);
            _localizationService.Translate();
            _volumeService.Enter();
            _audioService.Enter();
            // await _curtainView.HideCurtain();
            await GameReady(payload as IScenePayload);
        }

        public void Exit()
        {
            _focusService.Disable();
            _volumeService.Exit();
            _audioService.Exit();
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

        private async UniTask GameReady(IScenePayload payload)
        {
            if (payload.CanFromGameplay)
                return;

            _stickyService.ShowSticky();
            _sdcInitializeService.GameReady();
        }
    }
}