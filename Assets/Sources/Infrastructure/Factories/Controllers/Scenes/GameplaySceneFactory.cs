﻿using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Services.Upgrades;

namespace Sources.Infrastructure.Factories.Controllers.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IInputServiceUpdater _inputServiceUpdater;
        private readonly GameplaySceneViewFactory _gameplaySceneViewFactory;
        private readonly ILocalizationService _localizationService;
        private readonly ILoadService _loadService;
        private readonly IUpgradeService _upgradeService;

        public GameplaySceneFactory(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            GameplaySceneViewFactory gameplaySceneViewFactory,
            ILocalizationService localizationService,
            ILoadService loadService,
            IUpgradeService upgradeService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            _gameplaySceneViewFactory = gameplaySceneViewFactory ??
                                        throw new ArgumentNullException(nameof(gameplaySceneViewFactory));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        }

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene(
                _updateService,
                _inputServiceUpdater,
                _gameplaySceneViewFactory,
                _localizationService,
                _loadService,
                _upgradeService);
        }
    }
}