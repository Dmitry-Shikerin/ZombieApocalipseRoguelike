using Sirenix.OdinInspector;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.Domain.Models.AudioSources;
using Sources.Domain.Models.Upgrades.Configs.Containers;
using Sources.Infrastructure.Factories.Controllers.Musics;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Infrastructure.Factories.Controllers.Settings;
using Sources.Infrastructure.Factories.Domain.Data;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Services.Forms;
using Sources.Infrastructure.Services.LoadServices;
using Sources.Infrastructure.Services.LoadServices.Data;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Upgrades;
using Sources.Infrastructure.Services.Volumes;
using Sources.Infrastructure.Services.YandexSDKServices;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
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
            Container.BindInterfacesAndSelfTo<MainMenuSceneFactory>().AsSingle();
            Container.Bind<UpgradeConfigContainer>()
                .FromResource("Configs/Upgrades/Containers/UpgradeConfigContainer").AsSingle();
            Container.Bind<AudioClipCollection>().FromResource("Configs/MainMenuAudioClipContainer").AsSingle();
            Container.Bind<MainMenuSceneViewFactory>().AsSingle();
            
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

        private void BindFormFactories()
        {
            Container.Bind<MainMenuFormServiceFactory>().AsSingle();

            Container.Bind<AuthorizationFormPresenterFactory>().AsSingle();
            Container.Bind<LeaderboardFormPresenterFactory>().AsSingle();
            Container.Bind<MainMenuHudFormViewPresenterFactory>().AsSingle();
            Container.Bind<MainMenuSettingFormPresenterFactory>().AsSingle();
        }
        
        private void BindServices()
        {
            Container.Bind<IUpgradeConfigCollectionService>().To<UpgradeConfigCollectionService>().AsSingle();
            Container.Bind<IVolumeService>().To<VolumeService>().AsSingle();
            Container.Bind<IDataService>().To<PlayerPrefsDataService>().AsSingle();
            Container.Bind<ILeaderBoardInitializeService>().To<YandexLeaderBoardInitializeService>().AsSingle();
            Container.Bind<ILeaderBoardScoreSetter>().To<YandexLeaderBoardScoreSetter>().AsSingle();
            Container.Bind<ILoadService>().To<LoadService>().AsSingle();
            Container.Bind<IEntityRepository>().To<EntityRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
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