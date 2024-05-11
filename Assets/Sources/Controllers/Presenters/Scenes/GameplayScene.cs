using System;
using Sources.ControllersInterfaces.Scenes;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Infrastructure.Services.LevelCompleteds;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.Interstitials;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Curtains;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;
using UnityEngine;

namespace Sources.Controllers.Presenters.Scenes
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
        private readonly ILevelCompletedService _levelCompletedService;
        private readonly ITutorialService _tutorialService;
        private readonly CustomCollection<IEnemyView> _enemyCollection;
        private readonly IInterstitialShowerService _interstitialShowerService;
        private readonly CurtainView _curtainView;

        public GameplayScene(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            ILoadSceneService loadSceneService,
            ILocalizationService localizationService,
            ILoadService loadService,
            IUpgradeService upgradeService,
            IGameOverService gameOverService,
            IVolumeService volumeService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            ITutorialService tutorialService,
            CustomCollection<IEnemyView> enemyCollection,
            CurtainView curtainView,
            IInterstitialShowerService interstitialShowerService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? 
                                   throw new ArgumentNullException(nameof(inputServiceUpdater));
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _localizationService = localizationService ?? 
                                   throw new ArgumentNullException(nameof(localizationService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _levelCompletedService = levelCompletedService ?? 
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _enemyCollection = enemyCollection ?? 
                                     throw new ArgumentNullException(nameof(enemyCollection));
            _interstitialShowerService = interstitialShowerService ?? 
                                         throw new ArgumentNullException(nameof(interstitialShowerService));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }

        public async void Enter(object payload = null)
        {
            //TODO что лучше делать у сервисов Enter или Enable
            _loadSceneService.Load(payload as IScenePayload);
            _localizationService.Translate();
            _volumeService.Enter();
            _gameOverService.Enter();
            _saveService.Enter();
            _levelCompletedService.Enable();
            _tutorialService.Enable();
            _interstitialShowerService.Enter();
            _upgradeService.Enable();
            //TODO если закрываю игру раньше чем загрузилась курточка летят ошибки с юнитасками
            // await _curtainView.HideCurtain();
        }

        public void Exit()
        {
            _updateService.UnregisterAll();
            _gameOverService.Exit();
            _volumeService.Exit();
            _saveService.Exit();
            _levelCompletedService.Disable();
            _interstitialShowerService.Exit();
            _enemyCollection.Clear();
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