using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.App.Core;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Services.SceneLoaderServices;
using Sources.Infrastructure.Services.SceneServices;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.App
{
    public class AppCoreFactory
    {
        public AppCore Create()
        {
            AppCore appCore = new GameObject(nameof(AppCore)).AddComponent<AppCore>();

            ProjectContext projectContext = Object.FindObjectOfType<ProjectContext>();

            Dictionary<string, Func<object, SceneContext, UniTask<IScene>>> sceneFactories =
                new Dictionary<string, Func<object, SceneContext, UniTask<IScene>>>();
            SceneService sceneService = new SceneService(sceneFactories);
            projectContext.Container.BindInterfacesAndSelfTo<SceneService>().FromInstance(sceneService);

            sceneFactories["MainMenu"] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<MainMenuSceneFactory>().Create(payload);
            sceneFactories["Gameplay"] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories["TestGameplay"] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);

            sceneService.AddBeforeSceneChangeHandler(async sceneName => 
                await projectContext.Container.Resolve<ISceneLoaderService>().LoadSceneAsync(sceneName));
            
            appCore.Construct(sceneService);
            
            return appCore;
        }
    }
}