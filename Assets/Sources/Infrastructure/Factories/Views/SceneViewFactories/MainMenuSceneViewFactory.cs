using System;
using JetBrains.Annotations;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories
{
    public class MainMenuSceneViewFactory
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly MainMenuFormServiceFactory _mainMenuFormServiceFactory;

        public MainMenuSceneViewFactory(MainMenuHud mainMenuHud,
            MainMenuFormServiceFactory mainMenuFormServiceFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _mainMenuFormServiceFactory = mainMenuFormServiceFactory ??
                                          throw new ArgumentNullException(nameof(mainMenuFormServiceFactory));
        }

        public void Create() =>
            _mainMenuFormServiceFactory.Create().Show<MainMenuHudFormView>();
    }
}