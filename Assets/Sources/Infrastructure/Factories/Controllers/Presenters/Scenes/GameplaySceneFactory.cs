﻿using System;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Presenters.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.ServicesInterfaces.AudioSources;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdvertisingServices;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.Focuses;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.Gameplay;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.LevelCompleteds;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Curtains;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IInputServiceUpdater _inputServiceUpdater;
        private readonly ILocalizationService _localizationService;
        private readonly IGameOverService _gameOverService;
        private readonly IVolumeService _volumeService;
        private readonly LoadGameplaySceneService _loadGameplaySceneService;
        private readonly CreateGameplaySceneService _createGameplaySceneService;
        private readonly ISaveService _saveService;
        private readonly ILevelCompletedService _levelCompletedService;
        private readonly ITutorialService _tutorialService;
        private readonly CustomCollection<IEnemyView> _enemyCollection;
        private readonly IAudioService _audioService;
        private readonly IFocusService _focusService;
        private readonly IAdvertisingService _advertisingService;
        private readonly CurtainView _curtainView;

        public GameplaySceneFactory(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            ILocalizationService localizationService,
            IGameOverService gameOverService,
            IVolumeService volumeService,
            LoadGameplaySceneService loadGameplaySceneService,
            CreateGameplaySceneService createGameplaySceneService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            ITutorialService tutorialService,
            CustomCollection<IEnemyView> enemyCollection,
            CurtainView curtainView,
            IAudioService audioService,
            IFocusService focusService,
            IAdvertisingService advertisingService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadGameplaySceneService = loadGameplaySceneService ??
                                        throw new ArgumentNullException(nameof(loadGameplaySceneService));
            _createGameplaySceneService = createGameplaySceneService ??
                                          throw new ArgumentNullException(nameof(createGameplaySceneService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _levelCompletedService = levelCompletedService ??
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _advertisingService = advertisingService ?? throw new ArgumentNullException(nameof(advertisingService));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }

        public UniTask<IScene> Create(object payload)
        {
            IScene scene = new GameplayScene(
                _updateService,
                _inputServiceUpdater,
                CreateLoadSceneService(payload),
                _localizationService,
                _gameOverService,
                _volumeService,
                _saveService,
                _levelCompletedService,
                _tutorialService,
                _enemyCollection,
                _curtainView,
                _audioService,
                _focusService,
                _advertisingService);

            return UniTask.FromResult(scene);
        }

        private ILoadSceneService CreateLoadSceneService(object payload)
        {
            if (payload == null)
                return _createGameplaySceneService;

            var canLoad = payload is IScenePayload { CanLoad: true };

            if (canLoad == false)
                return _createGameplaySceneService;

            return _loadGameplaySceneService;
        }
    }
}