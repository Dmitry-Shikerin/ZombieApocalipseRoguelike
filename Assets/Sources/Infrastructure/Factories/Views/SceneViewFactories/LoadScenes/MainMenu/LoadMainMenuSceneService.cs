﻿using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu
{
    public class LoadMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly ILoadService _loadService;

        public LoadMainMenuSceneService(
            IEntityRepository entityRepository,
            ILoadService loadService,
            MainMenuHud mainMenuHud,
            VolumeViewFactory volumeViewFactory,
            IVolumeService volumeService,
            BackgroundMusicViewFactory backgroundMusicViewFactory,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            UiCollectorFactory uiCollectorFactory,
            IFormService formService)
            : base(
                mainMenuHud,
                volumeViewFactory,
                volumeService,
                backgroundMusicViewFactory,
                levelAvailabilityViewFactory,
                uiCollectorFactory,
                formService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = _loadService.Load<Tutorial>(ModelId.Tutorial);

            Volume volume = _loadService.Load<Volume>(ModelId.Volume);

            GameData gameData = _loadService.Load<GameData>(ModelId.GameData);

            SavedLevel savedLevel = _loadService.Load<SavedLevel>(ModelId.SavedLevel);

            Level firstLevel = _loadService.Load<Level>(ModelId.Gameplay);
            Level secondLevel = _loadService.Load<Level>(ModelId.Gameplay2);
            Level thirdLevel = _loadService.Load<Level>(ModelId.Gameplay3);
            Level fourthLevel = _loadService.Load<Level>(ModelId.Gameplay4);

            LevelAvailability levelAvailability = new LevelAvailability(
                new List<Level>()
                {
                    firstLevel,
                    secondLevel,
                    thirdLevel,
                    fourthLevel,
                });

            return new MainMenuModels(
                volume,
                firstLevel,
                secondLevel,
                thirdLevel,
                fourthLevel,
                levelAvailability,
                gameData,
                savedLevel,
                tutorial);
        }
    }
}