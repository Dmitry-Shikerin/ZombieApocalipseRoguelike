using System;
using JetBrains.Annotations;
using Sources.Domain.Setting;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories
{
    public class MainMenuSceneViewFactory
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly MainMenuFormServiceFactory _mainMenuFormServiceFactory;
        private readonly VolumeViewFactory _volumeViewFactory;

        public MainMenuSceneViewFactory(
            MainMenuHud mainMenuHud,
            MainMenuFormServiceFactory mainMenuFormServiceFactory,
            VolumeViewFactory volumeViewFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _mainMenuFormServiceFactory = mainMenuFormServiceFactory ??
                                          throw new ArgumentNullException(nameof(mainMenuFormServiceFactory));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
        }

        public void Create()
        {
            Volume volume = new Volume();  
            _volumeViewFactory.Create(volume, _mainMenuHud.VolumeView);
            
            _mainMenuFormServiceFactory.Create().Show<MainMenuHudFormView>();
        }
    }
}