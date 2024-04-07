using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using UnityEngine;

namespace Sources.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly IUpdateService _updateService;
        private readonly IInputServiceUpdater _inputServiceUpdater;
        private readonly GameplaySceneViewFactory _gameplaySceneViewFactory;
        private readonly ILocalizationService _localizationService;

        public GameplayScene(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            GameplaySceneViewFactory gameplaySceneViewFactory,
            ILocalizationService localizationService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            _gameplaySceneViewFactory = gameplaySceneViewFactory ?? 
                                        throw new ArgumentNullException(nameof(gameplaySceneViewFactory));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
        }

        public void Enter(object payload = null)
        {
            _gameplaySceneViewFactory.Create();
            _localizationService.Translate();
        }

        public void Exit()
        {
            _updateService.UnregisterAll();
        }

        public void Update(float deltaTime)
        {
            _updateService.Update(deltaTime);
            _inputServiceUpdater.Update(deltaTime);
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}