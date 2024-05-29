using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.App.Core;
using Sources.ControllersInterfaces.Scenes;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Data.Ids;
using Sources.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Infrastructure.Services.SceneServices;
using Sources.InfrastructureInterfaces.Services.SceneLoaderService;
using Sources.Presentations.UI.Curtains;
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

            CurtainView curtainView =
                Object.Instantiate(Resources.Load<CurtainView>(PrefabPath.Curtain)) ??
                throw new NullReferenceException(nameof(CurtainView));
            projectContext.Container.Bind<CurtainView>().FromInstance(curtainView);
            curtainView.Hide();

            Dictionary<string, Func<object, SceneContext, UniTask<IScene>>> sceneFactories =
                new Dictionary<string, Func<object, SceneContext, UniTask<IScene>>>();
            SceneService sceneService = new SceneService(sceneFactories);
            projectContext.Container.BindInterfacesAndSelfTo<SceneService>().FromInstance(sceneService);

            sceneFactories[ModelId.MainMenu] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<MainMenuSceneFactory>().Create(payload);
            sceneFactories[ModelId.Gameplay] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories["TestGameplay"] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[ModelId.Gameplay2] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[ModelId.Gameplay3] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[ModelId.Gameplay4] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);

            sceneService.AddBeforeSceneChangeHandler(async _ => await curtainView.ShowCurtain());

            sceneService.AddBeforeSceneChangeHandler(async sceneName =>
                await projectContext.Container.Resolve<ISceneLoaderService>().LoadSceneAsync(sceneName));

            appCore.Construct(sceneService);

            return appCore;
        }
    }
}