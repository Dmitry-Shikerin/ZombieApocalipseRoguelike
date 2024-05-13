using System;
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
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu
{
    public class CreateMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;

        public CreateMainMenuSceneService(
            ILoadService loadService,
            IEntityRepository entityRepository,
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
            _entityRepository = entityRepository;
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = new Tutorial();
            _entityRepository.Add(tutorial);

            Volume volume = CreateVolume();
            
            GameData gameData = new GameData(ModelId.GameData, true);
            _entityRepository.Add(gameData);

            SavedLevel savedLevel = new SavedLevel(ModelId.SavedLevel, false, ModelId.Gameplay);
            _entityRepository.Add(savedLevel);

            //LevelAvailability
            Level firstLevel = new Level(ModelId.Gameplay, false);
            _entityRepository.Add(firstLevel);
            Level secondLevel = new Level(ModelId.Gameplay2, false);
            _entityRepository.Add(secondLevel);
            Level thirdLevel = new Level(ModelId.Gameplay3, false);
            _entityRepository.Add(thirdLevel);
            Level fourthLevel = new Level(ModelId.Gameplay4, false);
            _entityRepository.Add(fourthLevel);

            LevelAvailability levelAvailability = new LevelAvailability(
                new List<Level>()
                {
                    firstLevel,
                    secondLevel,
                    thirdLevel,
                    fourthLevel,
                });

            Debug.Log("Created MainMenuModels");
            //TODO здесь сохраняю посли того  как создал все модели
            _loadService.SaveAll();

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

        private Volume CreateVolume()
        {
            if (_loadService.HasKey(ModelId.Volume))
                return _loadService.Load<Volume>(ModelId.Volume);

            Volume volume = new Volume();
            _entityRepository.Add(volume);
            
            return volume;
        }
    }
}