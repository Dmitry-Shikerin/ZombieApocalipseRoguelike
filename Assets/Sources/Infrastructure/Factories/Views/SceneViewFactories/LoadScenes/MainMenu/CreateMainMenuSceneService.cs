﻿using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;
using Sources.DomainInterfaces.Payloads;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Volumes;
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
            LevelAvailabilityViewFactory levelAvailabilityViewFactory) 
            : base(
                mainMenuHud,
                volumeViewFactory,
                volumeService,
                backgroundMusicViewFactory,
                levelAvailabilityViewFactory)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository;
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Volume volume = new Volume();
            _entityRepository.Add(volume);
            
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
                savedLevel);
        }
    }
}