using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Infrastructure.Factories.Controllers.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IInputServiceUpdater _inputServiceUpdater;
        private readonly GameplaySceneViewFactory _gameplaySceneViewFactory;

        public GameplaySceneFactory(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            GameplaySceneViewFactory gameplaySceneViewFactory)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            _gameplaySceneViewFactory = gameplaySceneViewFactory ??
                                        throw new ArgumentNullException(nameof(gameplaySceneViewFactory));
        }

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene(
                _updateService,
                _inputServiceUpdater,
                _gameplaySceneViewFactory);
        }
    }
}