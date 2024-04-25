using Sirenix.OdinInspector;
using Sources.Controllers.ModelViews.Forms.MainMenu;
using Sources.Domain.Models.AudioSources;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Domain.Models.Upgrades.Configs.Containers;
using Sources.Frameworks.MVVM.Infrastructure.Builders;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.MVVM.Presentations.Factories;
using Sources.Frameworks.PresentationInterfaces.Binder;
using Sources.Frameworks.Presentations.Binders;
using Sources.Infrastructure.Factories.Controllers.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Musics;
using Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Infrastructure.Factories.Controllers.Settings;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.YandexSDK;
using Sources.Infrastructure.Factories.Domain.Data;
using Sources.Infrastructure.Factories.Domain.Forms.MainMenu;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Factories.Views.YandexSDK;
using Sources.Infrastructure.Services.Forms;
using Sources.Infrastructure.Services.LoadServices;
using Sources.Infrastructure.Services.LoadServices.Data;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Upgrades;
using Sources.Infrastructure.Services.UseCases.Commands;
using Sources.Infrastructure.Services.UseCases.Queries;
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
            BindFormFactories();
            BindSettings();
            BindLevelAvailability();
            BindMusic();
            BindMvvm();
            BindMainMenuLoadService();
            BindDtoFactories();
        }

        private void BindMusic()
        {
            Container.Bind<BackgroundMusicPresenterFactory>().AsSingle();
            Container.Bind<BackgroundMusicViewFactory>().AsSingle();
        }
        
        private void BindServices()
        {
            Container.Bind<IUpgradeConfigCollectionService>().To<UpgradeConfigCollectionService>().AsSingle();
            Container.Bind<IVolumeService>().To<VolumeService>().AsSingle();
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            Container.Bind<IDataService>().To<PlayerPrefsDataService>().AsSingle();
            Container.Bind<ILeaderBoardInitializeService>().To<YandexLeaderBoardInitializeService>().AsSingle();
            Container.Bind<ILeaderBoardScoreSetter>().To<YandexLeaderBoardScoreSetter>().AsSingle();
            Container.Bind<ILoadService>().To<LoadService>().AsSingle();
            Container.Bind<IEntityRepository>().To<EntityRepository>().AsSingle();
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
        
        private void BindMvvm()
        {
            Container.Bind<IBinder>().To<Binder>().AsSingle();
            Container.Bind<IBindableViewFactory>().To<BindableViewFactory>().AsSingle();

            Container.Bind<GetVisibilityQuery>().AsSingle();
            Container.Bind<ShowCommand>().AsSingle();
            Container.Bind<HideCommand>().AsSingle();
        }

        private void BindFormFactories()
        {
            Container.Bind<MainMenuFormServiceFactory>().AsSingle();
            Container.Bind<LeaderBoardElementPresenterFactory>().AsSingle();
            Container.Bind<LeaderBoardElementViewFactory>().AsSingle();

            Container.Bind<MainMenuHudFormFactory>().AsSingle();
            Container.Bind<MainMenuSettingsFormFactory>().AsSingle();
            Container.Bind<AuthorizationFormFactory>().AsSingle();
            Container.Bind<LeaderboardFormFactory>().AsSingle();
            Container.Bind<NewGameFormFactory>().AsSingle();
            Container.Bind<WarningNewGameFormFactory>().AsSingle();

            Container.Bind<ShowMainMenuHudFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowNewGameFormViewModelComponentFactory>().AsSingle();
            Container.Bind<VisibilityViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowMainMenuSettingsFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowLeaderboardFormViewModelComponentFactory>().AsSingle();
            Container.Bind<LoadGameViewModelComponentFactory>().AsSingle();
            Container.Bind<TryShowNewGameFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowWarningNewGameFormViewModelComponentFactory>().AsSingle();

            Container
                .Bind<IViewModelFactory<MainMenuHudFormViewModel, MainMenuHudForm>>()
                .To<MainMenuHudFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<MainMenuSettingsFormViewModel, MainMenuSettingsForm>>()
                .To<MainMenuSettingsFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<AuthorizationFormViewModel, AuthorizationForm>>()
                .To<AuthorizationFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<LeaderboardFormViewModel, LeaderboardForm>>()
                .To<LeaderboardFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<NewGameFormViewModel, NewGameForm>>()
                .To<NewGameFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<WarningNewGameFormViewModel, WarningNewGameForm>>()
                .To<WarningNewGameFormViewModelFactory>()
                .AsSingle();

            Container
                .Bind<IBindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm>>()
                .To<BindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<MainMenuSettingsFormViewModel, MainMenuSettingsForm>>()
                .To<BindableViewBuilder<MainMenuSettingsFormViewModel, MainMenuSettingsForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<AuthorizationFormViewModel, AuthorizationForm>>()
                .To<BindableViewBuilder<AuthorizationFormViewModel, AuthorizationForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<LeaderboardFormViewModel, LeaderboardForm>>()
                .To<BindableViewBuilder<LeaderboardFormViewModel, LeaderboardForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<NewGameFormViewModel, NewGameForm>>()
                .To<BindableViewBuilder<NewGameFormViewModel, NewGameForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<WarningNewGameFormViewModel, WarningNewGameForm>>()
                .To<BindableViewBuilder<WarningNewGameFormViewModel, WarningNewGameForm>>()
                .AsSingle();
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