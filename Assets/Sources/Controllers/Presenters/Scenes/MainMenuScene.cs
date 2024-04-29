using System;
using Sources.ControllersInterfaces.Scenes;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.DomainInterfaces.Payloads;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Controllers.Presenters.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly ILoadSceneService _loadSceneService;
        private readonly IVolumeService _volumeService;
        private readonly ILocalizationService _localizationService;

        public MainMenuScene(
            ILoadSceneService loadSceneService,
            IVolumeService volumeService,
            ILocalizationService localizationService)
        {
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
        }
        
        public void Enter(object payload = null)
        {
            _loadSceneService.Load(payload as IScenePayload);
            _volumeService.Enter();
            _localizationService.Translate();
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
    }
}