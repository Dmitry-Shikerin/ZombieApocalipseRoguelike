using System;
using Sources.ControllersInterfaces.Scenes;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.DomainInterfaces.Payloads;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Controllers.Presenters.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly ILoadSceneService _loadSceneService;
        private readonly IVolumeService _volumeService;

        public MainMenuScene(
            ILoadSceneService loadSceneService,
            IVolumeService volumeService)
        {
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
        }
        
        public void Enter(object payload = null)
        {
            _loadSceneService.Load(payload as IScenePayload);
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
    }
}