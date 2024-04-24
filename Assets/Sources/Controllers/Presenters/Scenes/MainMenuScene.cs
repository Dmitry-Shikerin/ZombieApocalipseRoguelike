using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.Scenes;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Controllers.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly MainMenuSceneViewFactory _mainMenuSceneViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly MainMenuFormServiceFactory _mainMenuFormServiceFactory;

        public MainMenuScene(
            MainMenuSceneViewFactory mainMenuSceneViewFactory,
            IVolumeService volumeService,
            MainMenuFormServiceFactory menuFormServiceFactory)
        {
            _mainMenuSceneViewFactory = mainMenuSceneViewFactory ??
                                        throw new ArgumentNullException(nameof(mainMenuSceneViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _mainMenuFormServiceFactory = menuFormServiceFactory ??
                                      throw new ArgumentNullException(nameof(menuFormServiceFactory));
        }
        
        public void Enter(object payload = null)
        {
            _mainMenuSceneViewFactory.Create();
            _volumeService.Enter();
            _mainMenuFormServiceFactory.Create().Show<MainMenuHudForm>();
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