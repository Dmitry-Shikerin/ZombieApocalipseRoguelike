using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Services.Volumes;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Scenes
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        private readonly MainMenuSceneViewFactory _mainMenuSceneViewFactory;
        private readonly IVolumeService _volumeService;

        public MainMenuSceneFactory(
            MainMenuSceneViewFactory mainMenuSceneViewFactory,
            IVolumeService volumeService)
        {
            _mainMenuSceneViewFactory = mainMenuSceneViewFactory ??
                                        throw new ArgumentNullException(nameof(mainMenuSceneViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
        }
        
        public async UniTask<IScene> Create(object payload)
        {
            return new MainMenuScene(
                _mainMenuSceneViewFactory,
                _volumeService);
        }
    }
}