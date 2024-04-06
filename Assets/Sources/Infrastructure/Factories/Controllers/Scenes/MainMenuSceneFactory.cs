using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;

namespace Sources.Infrastructure.Factories.Controllers.Scenes
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        private readonly MainMenuSceneViewFactory _mainMenuSceneViewFactory;

        public MainMenuSceneFactory(MainMenuSceneViewFactory mainMenuSceneViewFactory)
        {
            _mainMenuSceneViewFactory = mainMenuSceneViewFactory ??
                                        throw new ArgumentNullException(nameof(mainMenuSceneViewFactory));
        }
        
        public async UniTask<IScene> Create(object payload)
        {
            return new MainMenuScene(_mainMenuSceneViewFactory);
        }
    }
}