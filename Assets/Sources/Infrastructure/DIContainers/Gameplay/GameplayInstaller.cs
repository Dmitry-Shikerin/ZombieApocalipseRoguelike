using Sirenix.OdinInspector;
using Sources.Domain.Models.AudioSources;
using Sources.Frameworks.UiFramework.Domain.Localizations.Configs;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.Presentation.Views;
using Sources.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.Gameplay;
using Sources.Infrastructure.Services.InputServices;
using Sources.Infrastructure.Services.Linecasts;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.Services.UpdateServices;
using Sources.Infrastructure.Services.Volumes;
using Sources.InfrastructureInterfaces.Services.Overlaps;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using Sources.Presentations.Views.RootGameObjects;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [Required][SerializeField] private GameplayHud _gameplayHud;
        [Required] [SerializeField] private RootGameObject _rootGameObject;
        [Required] [SerializeField] private ContainerView _containerView;
        
        public override void InstallBindings()
        {
            Container
                .Bind<AudioClipCollection>()
                .FromResource("Configs/GameplayAudioClipContainer")
                .AsSingle();
            Container
                .Bind<LocalizationConfig>()
                .FromResource("Configs/Localizations/LocalizationConfig")
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameplayHud>().FromInstance(_gameplayHud).AsSingle();
            Container.Bind<UiCollector>().FromInstance(_gameplayHud.UiCollector).AsSingle();
            Container.Bind<RootGameObject>().FromInstance(_rootGameObject).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
            
            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<NewInputService>().AsSingle();
            Container.Bind<LinecastService>().AsSingle();
            Container.Bind<IOverlapService>().To<OverlapService>().AsSingle();
            Container.Bind<LoadGameplaySceneService>().AsSingle();
            Container.Bind<CreateGameplaySceneService>().AsSingle();
            Container.Bind<CustomValidator>().AsSingle();
        }
    }
}