using System;
using Sources.ControllersInterfaces.Scenes;
using Sources.DomainInterfaces.Payloads;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes;
using Sources.Infrastructure.Services.SceneLoaderServices;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;
using UnityEngine;

namespace Sources.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly IUpdateService _updateService;
        private readonly IInputServiceUpdater _inputServiceUpdater;
        private readonly ILoadSceneService _loadSceneService;
        private readonly ILocalizationService _localizationService;
        private readonly ILoadService _loadService;
        private readonly IUpgradeService _upgradeService;
        private readonly IGameOverService _gameOverService;
        private readonly IVolumeService _volumeService;
        private readonly ISaveService _saveService;

        public GameplayScene(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            ILoadSceneService loadSceneService,
            ILocalizationService localizationService,
            ILoadService loadService,
            IUpgradeService upgradeService,
            IGameOverService gameOverService,
            IVolumeService volumeService,
            ISaveService saveService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
        }

        public void Enter(object payload = null)
        {
            _loadSceneService.Load(payload as IScenePayload);
            _localizationService.Translate();
            _gameOverService.Enter();
            _volumeService.Enter();
            _saveService.Enter();
            //TODO раскоментировать UpgradeService
            // _upgradeService.Enable();
        }

        public void Exit()
        {
            // _upgradeService.Disable();
            _updateService.UnregisterAll();
            _gameOverService.Exit();
            _volumeService.Exit();
            _saveService.Exit();
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