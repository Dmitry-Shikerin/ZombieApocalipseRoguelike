using Sirenix.OdinInspector;
using Sources.Domain.AudioSources;
using Sources.Domain.Upgrades.Configs.Containers;
using Sources.Infrastructure.Factories.Controllers.Abilities;
using Sources.Infrastructure.Factories.Controllers.Bears;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Infrastructure.Factories.Controllers.Common;
using Sources.Infrastructure.Factories.Controllers.Enemies;
using Sources.Infrastructure.Factories.Controllers.Enemies.Base;
using Sources.Infrastructure.Factories.Controllers.Enemies.Bosses;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Musics;
using Sources.Infrastructure.Factories.Controllers.Players;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.Controllers.Spawners;
using Sources.Infrastructure.Factories.Controllers.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Weapons;
using Sources.Infrastructure.Factories.Domain.Data;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Services.Localizations;
using Sources.Infrastructure.Factories.Views.Abilities;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Bullets;
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
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Factories.Views.Weapons;
using Sources.Infrastructure.Services.Forms;
using Sources.Infrastructure.Services.InputServices;
using Sources.Infrastructure.Services.Linecasts;
using Sources.Infrastructure.Services.LoadServices;
using Sources.Infrastructure.Services.LoadServices.Data;
using Sources.Infrastructure.Services.Localizations;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.Services.Providers;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Spawners;
using Sources.Infrastructure.Services.UpdateServices;
using Sources.Infrastructure.Services.Upgrades;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Factories.Views.ExplosionBodyBloodyViews;
using Sources.InfrastructureInterfaces.Factories.Views.FirstAidKits;
using Sources.InfrastructureInterfaces.Factories.Views.RewardItems;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Bullets;
using Sources.Presentations.Views.Enemies;
using Sources.Presentations.Views.Enemies.Bosses;
using Sources.Presentations.Views.ExplosionBodyBloodies;
using Sources.Presentations.Views.FirstAidKits;
using Sources.Presentations.Views.Localizations;
using Sources.Presentations.Views.RewardItems;
using Sources.Presentations.Views.RootGameObjects;
using Sources.PresentationsInterfaces.Views.Localizations;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        [Required][SerializeField] private GameplayHud _gameplayHud;
        [Required] [SerializeField] private RootGameObject _rootGameObject;
        
        public override void InstallBindings()
        {
            Container.Bind<UpgradeConfigContainer>()
                .FromResource("Configs/Upgrades/Containers/UpgradeConfigContainer").AsSingle();
            Container.Bind<AudioClipCollection>()
                .FromResource("Configs/AudioClipContainer").AsSingle();
            Container.Bind<GameplayHud>().FromInstance(_gameplayHud).AsSingle();
            Container.Bind<RootGameObject>().FromInstance(_rootGameObject).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
            Container.Bind<GameplaySceneViewFactory>().AsSingle();
            Container.Bind<IUpgradeCollectionService>().To<UpgradeCollectionService>().AsSingle();
            Container.Bind<IUpgradeService>().To<UpgradeService>().AsSingle();
            Container.Bind<PlayerWalletProvider>().AsSingle();
            
            BindServices();
            BindCharacters();
            BindFormFactories();
            BindWeapons();
            BindBear();
            BindEnemy();
            BindUpgrades();
            BindDtoFactories();
            BindItems();
            BindSpawners();
            BindGameplay();
            BindMusic();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<NewInputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
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
            Container.Bind<ILocalizationService>().To<TestLocalizationService>().AsSingle();
            Container.Bind<ITranslateServiceFactory<ITurkishTranslateService>>()
                .To<TurkishTranslateServiceFactory>().AsSingle();
            Container.Bind<ITranslateServiceFactory<IRussianTranslateService>>()
                .To<RussianTranslateServiceFactory>().AsSingle();
            Container.Bind<ITranslateServiceFactory<IEnglishTranslateService>>()
                .To<EnglishTranslateServiceFactory>().AsSingle();
            Container.Bind<ILoadService>().To<LoadService>().AsSingle();
            Container.Bind<IDataService>().To<PlayerPrefsDataService>().AsSingle();
            Container.Bind<IEntityRepository>().To<EntityRepository>().AsSingle();
        }

        private void BindGameplay()
        {
            Container.Bind<KillEnemyCounterPresenterFactory>().AsSingle();
            Container.Bind<KillEnemyCounterViewFactory>().AsSingle();
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
                .To<PlayerWalletDtoMapperMapper>().AsSingle();
        }
        
        private void BindFormFactories()
        {
            Container.Bind<GameplayFormServiceFactory>().AsSingle();
            Container.Bind<GamePlayTutorialFormServiceFactory>().AsSingle();        
            Container.Bind<PauseFormPresenterFactory>().AsSingle();
            Container.Bind<HudFormPresenterFactory>().AsSingle();
            Container.Bind<UpgradeFormPresenterFactory>().AsSingle();
            Container.Bind<TutorialFormPresenterFactory>().AsSingle();
            Container.Bind<GameplaySettingsFormPresenterFactory>().AsSingle();
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