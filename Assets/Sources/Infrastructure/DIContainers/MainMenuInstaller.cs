using Sirenix.OdinInspector;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.Domain.Models.AudioSources;
using Sources.Domain.Models.Spawners.Configs.Containers;
using Sources.Domain.Models.Upgrades.Configs.Containers;
using Sources.Frameworks.UiFramework.Domain.Configs.Localizations;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.Services.Forms;
using Sources.Frameworks.UiFramework.Services.Localizations;
using Sources.Frameworks.UiFramework.Services.Localizations.Translates.Common;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations.Translates.Common;
using Sources.Frameworks.YandexSdcFramework.Services.Leaderboards;
using Sources.Infrastructure.Factories;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Musics;
using Sources.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Infrastructure.Factories.Controllers.Settings;
using Sources.Infrastructure.Factories.Domain.Data;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Services.UiFramework.Forms;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Services.EnemySpawners;
using Sources.Infrastructure.Services.Forms;
using Sources.Infrastructure.Services.LoadServices;
using Sources.Infrastructure.Services.LoadServices.Data;
using Sources.Infrastructure.Services.PauseServices;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Tutorials;
using Sources.Infrastructure.Services.Upgrades;
using Sources.Infrastructure.Services.Volumes;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.InfrastructureInterfaces.Services.YandexSDKServices;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [Required] [SerializeField] private MainMenuHud _mainMenuHud;
        [Required] [SerializeField] private ContainerView _containerView;

        public override void InstallBindings()
        {
            Container.Bind<MainMenuHud>().FromInstance(_mainMenuHud).AsSingle();
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
            BindSettings();
            BindLevelAvailability();
            BindMusic();
            BindMainMenuLoadService();
            BindDtoFactories();
            BindFormFactories();
        }

        private void BindMusic()
        {
            Container.Bind<BackgroundMusicPresenterFactory>().AsSingle();
            Container.Bind<BackgroundMusicViewFactory>().AsSingle();
        }
        
        private void BindServices()
        {
            Container.Bind<ITutorialService>().To<TutorialService>().AsSingle();
            Container.Bind<IPauseService>().To<PauseService>().AsSingle();
            Container.Bind<IEnemySpawnerConfigCollectionService>().To<EnemySpawnerConfigCollectionService>().AsSingle();
            Container.Bind<IUpgradeConfigCollectionService>().To<UpgradeConfigCollectionService>().AsSingle();
            Container.Bind<IVolumeService>().To<VolumeService>().AsSingle();
            Container.Bind<IDataService>().To<PlayerPrefsDataService>().AsSingle();
            Container.Bind<ILeaderBoardInitializeService>().To<YandexLeaderBoardInitializeService>().AsSingle();
            Container.Bind<ILeaderBoardScoreSetter>().To<YandexLeaderBoardScoreSetter>().AsSingle();
            Container.Bind<ILoadService>().To<LoadService>().AsSingle();
            Container.Bind<IEntityRepository>().To<EntityRepository>().AsSingle();
            Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();
        }
        
        private void BindFormFactories()
        {
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            
            Container.Bind<MainMenuFormServiceFactory>().AsSingle();

            Container.Bind<FormButtonViewFactory>().AsSingle();

            Container.Bind<UiContainerFactory>().AsSingle();

            Container.Bind<UiContainerCustomServiceCollection>().AsSingle();
            Container.Bind<UiContainerGameOverService>().AsSingle();
            Container.Bind<FromLevelCompletedToMeinMenuSceneButtonClickService>().AsSingle();
            Container.Bind<CustomButtonClickServiceCollection>().AsSingle();
            Container.Bind<FromSettingsToPauseButtonClickService>().AsSingle();
            Container.Bind<LoadGameButtonClickService>().AsSingle();
            Container.Bind<FromSettingsToHudButtonClickService>().AsSingle();
            Container.Bind<LeaderBoardButtonClickService>().AsSingle();
            Container.Bind<FromWarningToNewGameButtonClickService>().AsSingle();
            Container.Bind<NewGameButtonClickService>().AsSingle();
            Container.Bind<CompleteTutorialButtonClickService>().AsSingle();
            Container.Bind<LoadMainMenuButtonClickService>().AsSingle();
            Container.Bind<UiFormButtonClickService>().AsSingle();
            Container.Bind<ButtonServiceCollection>().AsSingle();
            Container.Bind<PauseButtonService>().AsSingle();
            Container.Bind<VoidButtonService>().AsSingle();

            Container.Bind<UiContainerServicesCollection>().AsSingle();
            Container.Bind<UiContainerPauseService>().AsSingle();
            Container.Bind<UiContainerVoidService>().AsSingle();
        }

        private void BindMainMenuLoadService()
        {
            Container.Bind<CreateMainMenuSceneService>().AsSingle();
            Container.Bind<LoadMainMenuSceneService>().AsSingle();
        }
        
        private void BindDtoFactories()
        {
            Container.Bind<IUpgradeDtoMapper>().To<UpgradeDtoMapper>().AsSingle();
            Container.Bind<IPlayerWalletDtoMapper>()
                .To<PlayerWalletDtoMapper>().AsSingle();
            Container.Bind<ILevelDtoMapper>().To<LevelDtoMapper>().AsSingle();
            Container.Bind<IVolumeDtoMapper>().To<VolumeDtoMapper>().AsSingle();
            Container.Bind<ITutorialDtoMapper>().To<TutorialDtoMapper>().AsSingle();
            Container.Bind<IGameDataDtoMapper>().To<GameDataDtoMapper>().AsSingle();
            Container.Bind<IKillEnemyCounterDtoMapper>().To<KillEnemyCounterDtoMapper>().AsSingle();
            Container.Bind<ISavedLevelDtoMapper>().To<SavedLevelDtoMapper>().AsSingle();
            Container.Bind<IEnemySpawnerDtoMapper>().To<EnemySpawnerDtoMapper>().AsSingle();
        }

        private void BindSettings()
        {
            Container.Bind<VolumePresenterFactory>().AsSingle();
            Container.Bind<VolumeViewFactory>().AsSingle();
        }

        private void BindLevelAvailability()
        {
            Container.Bind<LevelAvailabilityPresenterFactory>().AsSingle();
            Container.Bind<LevelAvailabilityViewFactory>().AsSingle();
        }
    }
}