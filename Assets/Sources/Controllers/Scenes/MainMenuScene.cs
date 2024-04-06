﻿using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;

namespace Sources.Controllers.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly MainMenuSceneViewFactory _mainMenuSceneViewFactory;

        public MainMenuScene(MainMenuSceneViewFactory mainMenuSceneViewFactory)
        {
            _mainMenuSceneViewFactory = mainMenuSceneViewFactory ??
                                        throw new ArgumentNullException(nameof(mainMenuSceneViewFactory));
        }
        
        public void Enter(object payload = null)
        {
            _mainMenuSceneViewFactory.Create();
        }

        public void Exit()
        {
        }

        public void Update(float deltaTime)
        {
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}