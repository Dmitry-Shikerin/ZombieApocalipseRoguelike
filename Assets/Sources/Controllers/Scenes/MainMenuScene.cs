using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Controllers.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly MainMenuSceneViewFactory _mainMenuSceneViewFactory;
        private readonly IVolumeService _volumeService;

        public MainMenuScene(
            MainMenuSceneViewFactory mainMenuSceneViewFactory,
            IVolumeService volumeService)
        {
            _mainMenuSceneViewFactory = mainMenuSceneViewFactory ??
                                        throw new ArgumentNullException(nameof(mainMenuSceneViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
        }
        
        public void Enter(object payload = null)
        {
            _mainMenuSceneViewFactory.Create();
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