using Sirenix.OdinInspector;
using Sources.Controllers.Common.Forms;
using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.Domain.Models.AudioSources;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Domain.Models.Spawners.Configs.Containers;
using Sources.Domain.Models.Upgrades.Configs.Containers;
using Sources.Frameworks.MVVM.Infrastructure.Builders;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.MVVM.Presentations.Factories;
using Sources.Frameworks.PresentationInterfaces.Binder;
using Sources.Frameworks.Presentations.Binders;
using Sources.Frameworks.UiFramework.Domain.Configs.Localizations;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Localizations;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.Services.Forms;
using Sources.Frameworks.UiFramework.Services.Localizations;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations.Translates;
using Sources.Infrastructure.Factories;
using Sources.Infrastructure.Factories.Controllers.Abilities;
using Sources.Infrastructure.Factories.Controllers.Bears;
using Sources.Infrastructure.Factories.Controllers.Cameras;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Infrastructure.Factories.Controllers.Common;
using Sources.Infrastructure.Factories.Controllers.Enemies;
using Sources.Infrastructure.Factories.Controllers.Enemies.Base;
using Sources.Infrastructure.Factories.Controllers.Enemies.Bosses;
using Sources.Infrastructure.Factories.Controllers.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Players;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Infrastructure.Factories.Controllers.Presenters.Musics;
using Sources.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Settings;
using Sources.Infrastructure.Factories.Controllers.Spawners;
using Sources.Infrastructure.Factories.Controllers.Upgrades;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Weapons;
using Sources.Infrastructure.Factories.Domain.Data;
using Sources.Infrastructure.Factories.Domain.Forms.Gameplay;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Services.UiFramework.Forms;
using Sources.Infrastructure.Factories.Views.Abilities;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Bullets;
using Sources.Infrastructure.Factories.Views.Cameras;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Commons;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.Infrastructure.Factories.Views.Enemies.Base;
using Sources.Infrastructure.Factories.Views.Enemies.Bosses;
using Sources.Infrastructure.Factories.Views.ExplosionBodyBloodyViews;
using Sources.Infrastructure.Factories.Views.FirstAidKitViewFactory;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Players;
using Sources.Infrastructure.Factories.Views.RewardItems;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.Gameplay;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Factories.Views.Weapons;
using Sources.Infrastructure.Services.Cameras;
using Sources.Infrastructure.Services.EnemyCollectors;
using Sources.Infrastructure.Services.EnemySpawners;
using Sources.Infrastructure.Services.Forms;
using Sources.Infrastructure.Services.GameOvers;
using Sources.Infrastructure.Services.InputServices;
using Sources.Infrastructure.Services.LevelCompleteds;
using Sources.Infrastructure.Services.Linecasts;
using Sources.Infrastructure.Services.LoadServices;
using Sources.Infrastructure.Services.LoadServices.Data;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.Services.PauseServices;
using Sources.Infrastructure.Services.Providers;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Saves;
using Sources.Infrastructure.Services.Spawners;
using Sources.Infrastructure.Services.Tutorials;
using Sources.Infrastructure.Services.UpdateServices;
using Sources.Infrastructure.Services.Upgrades;
using Sources.Infrastructure.Services.UseCases.Commands;
using Sources.Infrastructure.Services.UseCases.Queries;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Factories.Views.ExplosionBodyBloodyViews;
using Sources.InfrastructureInterfaces.Factories.Views.FirstAidKits;
using Sources.InfrastructureInterfaces.Factories.Views.RewardItems;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Bullets;
using Sources.Presentations.Views.Enemies.Base;
using Sources.Presentations.Views.Enemies.Bosses;
using Sources.Presentations.Views.ExplosionBodyBloodies;
using Sources.Presentations.Views.FirstAidKits;
using Sources.Presentations.Views.RewardItems;
using Sources.Presentations.Views.RootGameObjects;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        [Required][SerializeField] private GameplayHud _gameplayHud;
        [Required] [SerializeField] private RootGameObject _rootGameObject;
        [Required] [SerializeField] private ContainerView _containerView;
        
        public override void InstallBindings()
        {
            Container
                .Bind<UpgradeConfigContainer>()
                .FromResource("Configs/Upgrades/Containers/UpgradeConfigContainer")
                .AsSingle();
            Container
                .Bind<AudioClipCollection>()
                .FromResource("Configs/GameplayAudioClipContainer")
                .AsSingle();
            Container
                .Bind<LocalizationConfig>()
                .FromResource("Configs/Localizations/LocalizationConfig")
                .AsSingle();
            Container
                .Bind<EnemySpawnerConfigContainer>()
                .FromResource("Configs/EnemySpawners/Containers/EnemySpawnerConfigContainer")
                .AsSingle();
            Container.Bind<GameplayHud>().FromInstance(_gameplayHud).AsSingle();
            Container.Bind<UiCollector>().FromInstance(_gameplayHud.UiCollector).AsSingle();
            Container.Bind<RootGameObject>().FromInstance(_rootGameObject).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
            Container.Bind<IUpgradeCollectionService>().To<UpgradeCollectionService>().AsSingle();
            Container.Bind<IUpgradeService>().To<UpgradeService>().AsSingle();
            Container.Bind<PlayerWalletProvider>().AsSingle();
            
            BindServices();
            BindCharacters();
            BindWeapons();
            BindBear();
            BindEnemy();
            BindUpgrades();
            BindDtoFactories();
            BindItems();
            BindSpawners();
            BindGameplay();
            BindMusic();
            BindSettings();
            BindFormFactories();
        }

        //TODO разбить все на отдельные моноинсталлеры
        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<NewInputService>().AsSingle();
            Container.Bind<LinecastService>().AsSingle();
            Container.Bind<OverlapService>().AsSingle();
            Container.Bind<IUpgradeConfigCollectionService>().To<UpgradeConfigCollectionService>().AsSingle();
            Container.Bind<IObjectPool<BulletView>>().To<ObjectPool<BulletView>>().AsSingle();
            Container.Bind<IObjectPool<EnemyView>>().To<ObjectPool<EnemyView>>().AsSingle();
            Container.Bind<IObjectPool<ExplosionBodyBloodyView>>().To<ObjectPool<ExplosionBodyBloodyView>>().AsSingle();
            Container.Bind<IObjectPool<FirstAidKitView>>().To<ObjectPool<FirstAidKitView>>().AsSingle();
            Container.Bind<IObjectPool<RewardItemView>>().To<ObjectPool<RewardItemView>>().AsSingle();
            Container.Bind<IObjectPool<BossEnemyView>>().To<ObjectPool<BossEnemyView>>().AsSingle();
            Container.Bind<IBulletSpawnService>().To<BulletSpawnService>().AsSingle();
            Container.Bind<IEnemySpawnService>().To<EnemySpawnService>().AsSingle();
            Container.Bind<IBossEnemySpawnService>().To<BossEnemySpawnService>().AsSingle();
            Container.Bind<IExplosionBodyBloodySpawnService>().To<ExplosionBodyBloodySpawnService>().AsSingle();
            Container.Bind<IFirstAidKitSpawnService>().To<FirstAidKitSpawnService>().AsSingle();
            Container.Bind<IRewardItemSpawnService>().To<RewardItemSpawnService>().AsSingle();
            Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();
            Container.Bind<ILoadService>().To<LoadService>().AsSingle();
            Container.Bind<IDataService>().To<PlayerPrefsDataService>().AsSingle();
            Container.Bind<IEntityRepository>().To<EntityRepository>().AsSingle();
            Container.Bind<IPauseService>().To<PauseService>().AsSingle();
            Container.Bind<IEnemyCollectorService>().To<EnemyCollectorService>().AsSingle();
            Container.Bind<IGameOverService>().To<GameOverService>().AsSingle();
            Container.Bind<ICameraService>().To<CameraService>().AsSingle();
            Container.Bind<LoadGameplaySceneService>().AsSingle();
            Container.Bind<CreateGameplaySceneService>().AsSingle();
            Container.Bind<ISaveService>().To<SaveService>().AsSingle();
            Container.Bind<ILevelCompletedService>().To<LevelCompletedService>().AsSingle();
            Container.Bind<ITutorialService>().To<TutorialService>().AsSingle();
            Container.Bind<IEnemySpawnerConfigCollectionService>().To<EnemySpawnerConfigCollectionService>().AsSingle();
        }

        private void BindFormFactories()
        {
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            
            Container.Bind<GameplayFormServiceFactory>().AsSingle();

            Container.Bind<FormButtonViewFactory>().AsSingle();

            Container.Bind<UiContainerFactory>().AsSingle();

            Container.Bind<CustomButtonClickServiceCollection>().AsSingle();
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

        private void BindGameplay()
        {
            Container.Bind<KillEnemyCounterPresenterFactory>().AsSingle();
            Container.Bind<KillEnemyCounterViewFactory>().AsSingle();
        }
        
        private void BindSettings()
        {
            Container.Bind<VolumePresenterFactory>().AsSingle();
            Container.Bind<VolumeViewFactory>().AsSingle();
        }

        private void BindMusic()
        {
            Container.Bind<BackgroundMusicPresenterFactory>().AsSingle();
            Container.Bind<BackgroundMusicViewFactory>().AsSingle();
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
        
        
        private void BindCharacters()
        {
            Container.Bind<CharacterViewFactory>().AsSingle();
            
            Container.Bind<CharacterMovementPresenterFactory>().AsSingle();
            Container.Bind<CharacterMovementViewFactory>().AsSingle();

            Container.Bind<CharacterAttackerPresenterFactory>().AsSingle();
            Container.Bind<CharacterAttackerViewFactory>().AsSingle();

            Container.Bind<CharacterHealthPresenterFactory>().AsSingle();
            Container.Bind<CharacterHealthViewFactory>().AsSingle();

            Container.Bind<CharacterWalletPresenterFactory>().AsSingle();
            Container.Bind<CharacterWalletViewFactory>().AsSingle();

            Container.Bind<PlayerWalletPresenterFactory>().AsSingle();
            Container.Bind<PlayerWalletViewFactory>().AsSingle();

            Container.Bind<EnemyIndicatorPresenterFactory>().AsSingle();
            Container.Bind<EnemyIndicatorViewFactory>().AsSingle();

            Container.Bind<CameraPresenterFactory>().AsSingle();
            Container.Bind<CameraViewFactory>().AsSingle();
        }

        private void BindItems()
        {
            Container.Bind<IFirstAidKitViewFactory>().To<FirstAidKitViewFactory>().AsSingle();
            Container.Bind<IRewardItemViewFactory>().To<RewardItemViewFactory>().AsSingle();
        }

        private void BindBear()
        {
            Container.Bind<BearPresenterFactory>().AsSingle();
            Container.Bind<BearViewFactory>().AsSingle();
        }

        private void BindWeapons()
        {
            Container.Bind<MiniGunPresenterFactory>().AsSingle();
            Container.Bind<MiniGunViewFactory>().AsSingle();

            Container.Bind<IBulletViewFactory>().To<BulletViewFactory>().AsSingle();

            Container.Bind<SawLauncherAbilityPresenterFactory>().AsSingle();
            Container.Bind<SawLauncherAbilityViewFactory>().AsSingle();

            Container.Bind<SawLauncherPresenterFactory>().AsSingle();
            Container.Bind<SawLauncherViewFactory>().AsSingle();
        }

        private void BindSpawners()
        {
            Container.Bind<EnemySpawnPresenterFactory>().AsSingle();
            Container.Bind<EnemySpawnViewFactory>().AsSingle();

            Container.Bind<ItemSpawnerPresenterFactory>().AsSingle();
            Container.Bind<ItemSpawnerViewFactory>().AsSingle();
        }
        
        private void BindEnemy()
        {
            Container.Bind<HealthUiPresenterFactory>().AsSingle();
            Container.Bind<HealthUiFactory>().AsSingle();

            Container.Bind<HealthUiTextPresenterFactory>().AsSingle();
            Container.Bind<HealthUiTextViewFactory>().AsSingle();

            Container.Bind<BossEnemyPresenterFactory>().AsSingle();
            Container.Bind<IBossEnemyViewFactory>().To<BossEnemyViewFactory>().AsSingle();
            
            Container.Bind<EnemyHealthPresenterFactory>().AsSingle();
            Container.Bind<EnemyHealthViewFactory>().AsSingle();
            Container.Bind<EnemyPresenterFactory>().AsSingle();
            Container.Bind<IEnemyViewFactory>().To<EnemyViewFactory>().AsSingle();
            Container.Bind<IExplosionBodyBloodyViewFactory>().To<ExplosionBodyBloodyViewFactory>().AsSingle();
        }

        private void BindUpgrades()
        {
            Container.Bind<UpgradePresenterFactory>().AsSingle();
            Container.Bind<UpgradeViewFactory>().AsSingle();

            Container.Bind<UpgradeUiPresenterFactory>().AsSingle();
            Container.Bind<UpgradeUiFactory>().AsSingle();
        }
    }
}