using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;
using Sources.DomainInterfaces.Payloads;
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
    public class LoadMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly IEntityRepository _entityRepository;
        private readonly ILoadService _loadService;

        public LoadMainMenuSceneService(
            IEntityRepository entityRepository,
            ILoadService loadService,
            MainMenuHud mainMenuHud,
            VolumeViewFactory volumeViewFactory, 
            IVolumeService volumeService,
            BackgroundMusicViewFactory backgroundMusicViewFactory, 
            LevelAvailabilityViewFactory levelAvailabilityViewFactory) 
            : base(
                mainMenuHud, 
                volumeViewFactory, 
                volumeService, 
                backgroundMusicViewFactory, 
                levelAvailabilityViewFactory)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            _loadService.LoadAll();
            
            Volume volume = _entityRepository.Get(ModelId.Volume) as Volume;
            
            GameData gameData = _entityRepository.Get(ModelId.GameData) as GameData;
            
            SavedLevel savedLevel = _entityRepository.Get(ModelId.SavedLevel) as SavedLevel;
            
            //LevelAvailability
            Level firstLevel = _entityRepository.Get(ModelId.Gameplay) as Level;
            Level secondLevel = _entityRepository.Get(ModelId.Gameplay2) as Level;
            Level thirdLevel = _entityRepository.Get(ModelId.Gameplay3) as Level;
            Level fourthLevel = _entityRepository.Get(ModelId.Gameplay4) as Level;
            
            LevelAvailability levelAvailability = new LevelAvailability(
                new List<Level>()
                {
                    firstLevel,
                    secondLevel,
                    thirdLevel,
                    fourthLevel,
                });
            
            Debug.Log("LoadMainMenu models");
            
            return new MainMenuModels(
                volume,
                firstLevel, 
                secondLevel,
                thirdLevel,
                fourthLevel,
                levelAvailability,
                gameData,
                savedLevel);
        }
    }
}