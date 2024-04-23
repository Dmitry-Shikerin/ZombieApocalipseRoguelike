using System;
using System.Collections.Generic;
using Sources.Domain.Gameplay;
using Sources.Domain.Setting;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories
{
    public class MainMenuSceneViewFactory
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly MainMenuFormServiceFactory _mainMenuFormServiceFactory;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly LevelAvailabilityViewFactory _levelAvailabilityViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly BackgroundMusicViewFactory _backgroundMusicViewFactory;

        public MainMenuSceneViewFactory(
            MainMenuHud mainMenuHud,
            MainMenuFormServiceFactory mainMenuFormServiceFactory,
            VolumeViewFactory volumeViewFactory,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            IVolumeService volumeService,
            BackgroundMusicViewFactory backgroundMusicViewFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _mainMenuFormServiceFactory = mainMenuFormServiceFactory ??
                                          throw new ArgumentNullException(nameof(mainMenuFormServiceFactory));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _levelAvailabilityViewFactory = levelAvailabilityViewFactory ?? 
                                            throw new ArgumentNullException(nameof(levelAvailabilityViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _backgroundMusicViewFactory = backgroundMusicViewFactory ??
                                          throw new ArgumentNullException(nameof(backgroundMusicViewFactory));
        }

        public void Create()
        {
            //Volume
            Volume volume = new Volume();  
            _volumeViewFactory.Create(volume, _mainMenuHud.VolumeView);
            _volumeService.Register(volume);
            
            //BackgroundMusic
            _backgroundMusicViewFactory.Create(_mainMenuHud.BackgroundMusicView);
            
            //LevelAvailability
            Level firstLevel = new Level("Level 1", false);
            Level secondLevel = new Level("Level 2", false);
            Level thirdLevel = new Level("Level 3", false);
            Level fourthLevel = new Level("Level 4", false);
            LevelAvailability levelAvailability = new LevelAvailability(
                new List<Level>()
                {
                    firstLevel,
                    secondLevel,
                    thirdLevel,
                    fourthLevel,
                });
            _levelAvailabilityViewFactory.Create(levelAvailability, _mainMenuHud.LevelAvailabilityView);
            
            //FormService
            // _mainMenuFormServiceFactory.Create().Show<MainMenuHudFormView>();
        }
    }
}