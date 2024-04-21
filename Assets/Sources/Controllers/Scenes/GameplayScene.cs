using System;
using Sources.ControllersInterfaces.Scenes;
using Sources.DomainInterfaces.Payloads;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using UnityEngine;

namespace Sources.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly IUpdateService _updateService;
        private readonly IInputServiceUpdater _inputServiceUpdater;
        private readonly GameplaySceneViewFactory _gameplaySceneViewFactory;
        private readonly ILocalizationService _localizationService;
        private readonly ILoadService _loadService;
        private readonly IUpgradeService _upgradeService;
        private readonly IGameOverService _gameOverService;

        public GameplayScene(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            GameplaySceneViewFactory gameplaySceneViewFactory,
            ILocalizationService localizationService,
            ILoadService loadService,
            IUpgradeService upgradeService,
            IGameOverService gameOverService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            _gameplaySceneViewFactory = gameplaySceneViewFactory ?? 
                                        throw new ArgumentNullException(nameof(gameplaySceneViewFactory));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
        }

        public void Enter(object payload = null)
        {
            _gameplaySceneViewFactory.Create(payload as IScenePayload);
            _localizationService.Translate();
            _gameOverService.Enter();
            //TODO раскоментировать UpgradeService
            // _upgradeService.Enable();
        }

        public void Exit()
        {
            // _upgradeService.Disable();
            _updateService.UnregisterAll();
            _gameOverService.Exit();
        }

        public void Update(float deltaTime)
        {
            _updateService.Update(deltaTime);
            _inputServiceUpdater.Update(deltaTime);
            
            if(Input.GetKeyDown(KeyCode.P))
                _loadService.SaveAll();
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}