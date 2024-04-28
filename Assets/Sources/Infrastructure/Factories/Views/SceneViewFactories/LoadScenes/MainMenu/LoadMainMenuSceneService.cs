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
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = _loadService.Load<Tutorial>(ModelId.Tutorial);
            
            //TODO подумать над тем какие айдишки загружать
            Volume volume = _loadService.Load<Volume>(ModelId.Volume);
            
            GameData gameData = _loadService.Load<GameData>(ModelId.GameData);
            
            SavedLevel savedLevel = _loadService.Load<SavedLevel>(ModelId.SavedLevel);
            
            //LevelAvailability
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
            
            Debug.Log("LoadMainMenu models");
            
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