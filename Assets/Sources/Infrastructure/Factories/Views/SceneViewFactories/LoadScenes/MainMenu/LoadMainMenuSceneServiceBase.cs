﻿using System;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Payloads;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Services.UiFramework.Forms;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu
{
    public abstract class LoadMainMenuSceneServiceBase : ILoadSceneService
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly BackgroundMusicViewFactory _backgroundMusicViewFactory;
        private readonly LevelAvailabilityViewFactory _levelAvailabilityViewFactory;
        private readonly MainMenuFormServiceFactory _mainMenuFormServiceFactory;

        protected LoadMainMenuSceneServiceBase(
            MainMenuHud mainMenuHud,
            VolumeViewFactory volumeViewFactory,
            IVolumeService volumeService,
            BackgroundMusicViewFactory backgroundMusicViewFactory,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            MainMenuFormServiceFactory mainMenuFormServiceFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _backgroundMusicViewFactory = backgroundMusicViewFactory ?? 
                                          throw new ArgumentNullException(nameof(backgroundMusicViewFactory));
            _levelAvailabilityViewFactory = levelAvailabilityViewFactory ?? 
                                            throw new ArgumentNullException(nameof(levelAvailabilityViewFactory));
            _mainMenuFormServiceFactory = mainMenuFormServiceFactory ?? throw new ArgumentNullException(nameof(mainMenuFormServiceFactory));
        }

        public void Load(IScenePayload scenePayload)
        {
            MainMenuModels models = LoadModels(scenePayload);
            
            //SavedLevel
            SavedLevel savedLevel = models.SavedLevel;
            
            //Volume
            _volumeViewFactory.Create(models.Volume, _mainMenuHud.VolumeView);
            _volumeService.Register(models.Volume);
            
            //BackgroundMusic
            _backgroundMusicViewFactory.Create(_mainMenuHud.BackgroundMusicView);
            
            //LevelAvailability
            _levelAvailabilityViewFactory.Create(models.LevelAvailability, _mainMenuHud.LevelAvailabilityView);
            
            //FormService
            _mainMenuFormServiceFactory.Create().Show(FormId.Hud);
        }
        
        protected abstract MainMenuModels LoadModels(IScenePayload scenePayload);
    }
}