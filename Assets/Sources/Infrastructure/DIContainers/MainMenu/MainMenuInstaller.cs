using Sirenix.OdinInspector;
using Sources.Domain.Models.AudioSources;
using Sources.Domain.Models.Spawners.Configs.Containers;
using Sources.Domain.Models.Upgrades.Configs.Containers;
using Sources.Frameworks.UiFramework.Domain.Localizations.Configs;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.YandexSdcFramework.Services.Focuses;
using Sources.Frameworks.YandexSdcFramework.Services.Leaderboards;
using Sources.Frameworks.YandexSdcFramework.Services.PlayerAccounts;
using Sources.Frameworks.YandexSdcFramework.Services.SdcInitializeServices;
using Sources.Frameworks.YandexSdcFramework.Services.Stickies;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.Focuses;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.Leaderboads;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.PlayerAccounts;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.SdcInitializeServices;
using Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Infrastructure.Factories.Controllers.YandexSDK;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu;
using Sources.Infrastructure.Factories.Views.YandexSDK;
using Sources.Infrastructure.Services.EnemySpawners;
using Sources.Infrastructure.Services.PauseServices;
using Sources.Infrastructure.Services.Upgrades;
using Sources.Infrastructure.Services.Volumes;
using Sources.InfrastructureInterfaces.Services.EnemySpawners;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.YandexSDKServices;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DIContainers.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        [Required] [SerializeField] private MainMenuHud _mainMenuHud;
        [Required] [SerializeField] private ContainerView _containerView;

        //TODO разделить этот мусор в отдельные файлы
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuHud>().FromInstance(_mainMenuHud).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.Bind<UiCollector>().FromInstance(_mainMenuHud.UiCollector).AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuSceneFactory>().AsSingle();
            Container
                .Bind<UpgradeConfigContainer>()
                .FromResource("Configs/Upgrades/Containers/UpgradeConfigContainer")
                .AsSingle();
            Container
                .Bind<LocalizationConfig>()
                .FromResource("Configs/Localizations/LocalizationConfig")
                .AsSingle();
            Container.Bind<AudioClipCollection>().FromResource("Configs/MainMenuAudioClipContainer").AsSingle();
            Container
                .Bind<EnemySpawnerConfigContainer>()
                .FromResource("Configs/EnemySpawners/Containers/EnemySpawnerConfigContainer")
                .AsSingle();

            BindServices();
            BindLevelAvailability();
            BindMainMenuLoadService();
        }

        //TODO вытащить в отделтный инсталлер
        private void BindServices()
        {
            Container.Bind<IPauseService>().To<PauseService>().AsSingle();
            Container.Bind<IEnemySpawnerConfigCollectionService>().To<EnemySpawnerConfigCollectionService>().AsSingle();
            Container.Bind<IUpgradeConfigCollectionService>().To<UpgradeConfigCollectionService>().AsSingle();
            Container.Bind<ILeaderboardInitializeService>().To<YandexLeaderboardInitializeService>().AsSingle();
            Container.Bind<ILeaderBoardScoreSetter>().To<YandexLeaderBoardScoreSetter>().AsSingle();
            Container.Bind<IPlayerAccountAuthorizeService>().To<PlayerAccountAuthorizeService>().AsSingle();
            Container.Bind<ISdcInitializeService>().To<SdcInitializeService>().AsSingle();
            Container.Bind<IStickyService>().To<StickyService>().AsSingle();
            Container.Bind<IFocusService>().To<FocusService>().AsSingle();
            Container.Bind<LeaderBoardElementViewFactory>().AsSingle();
            Container.Bind<LeaderBoardElementPresenterFactory>().AsSingle();
            Container.Bind<CustomValidator>().AsSingle();
        }

        private void BindMainMenuLoadService()
        {
            Container.Bind<CreateMainMenuSceneService>().AsSingle();
            Container.Bind<LoadMainMenuSceneService>().AsSingle();
        }
        
        private void BindLevelAvailability()
        {
            Container.Bind<LevelAvailabilityPresenterFactory>().AsSingle();
            Container.Bind<LevelAvailabilityViewFactory>().AsSingle();
        }
    }
}