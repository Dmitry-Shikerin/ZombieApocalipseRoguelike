using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;
using Sources.DomainInterfaces.Payloads;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Services.UiFramework.Forms;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.LoadServices;
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
            MainMenuFormServiceFactory mainMenuFormServiceFactory)
            : base(
                mainMenuHud,
                volumeViewFactory,
                volumeService,
                backgroundMusicViewFactory,
                levelAvailabilityViewFactory,
                mainMenuFormServiceFactory)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository;
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = new Tutorial();
            _entityRepository.Add(tutorial);

            Volume volume;
            
            if (_loadService.HasKey(ModelId.Volume))
            {
                volume = _loadService.Load<Volume>(ModelId.Volume);
            }
            else
            {
                volume = new Volume();
                _entityRepository.Add(volume);
            }

            GameData gameData = new GameData(ModelId.GameData, true);
            _entityRepository.Add(gameData);

            SavedLevel savedLevel = new SavedLevel(ModelId.SavedLevel, false, ModelId.Gameplay);
            _entityRepository.Add(savedLevel);

            //LevelAvailability
            Level firstLevel = new Level(ModelId.Gameplay, true);
            _entityRepository.Add(firstLevel);
            Level secondLevel = new Level(ModelId.Gameplay2, true);
            _entityRepository.Add(secondLevel);
            Level thirdLevel = new Level(ModelId.Gameplay3, true);
            _entityRepository.Add(thirdLevel);
            Level fourthLevel = new Level(ModelId.Gameplay4, true);
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
    }
}