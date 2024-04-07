using Sirenix.OdinInspector;
using Sources.Infrastructure.Factories.Controllers.Abilities;
using Sources.Infrastructure.Factories.Controllers.Bears;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Infrastructure.Factories.Controllers.Common;
using Sources.Infrastructure.Factories.Controllers.Enemies;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.Controllers.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Abilities;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Bullets;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Commons;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Factories.Views.Weapons;
using Sources.Infrastructure.Services.Forms;
using Sources.Infrastructure.Services.InputServices;
using Sources.Infrastructure.Services.Linecasts;
using Sources.Infrastructure.Services.Localizations;
using Sources.Infrastructure.Services.Localizations.Translates;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.Services.Spawners;
using Sources.Infrastructure.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Bullets;
using Sources.Presentations.Views.Localizations;
using Sources.PresentationsInterfaces.Views.Localizations;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        [Required][SerializeField] private GameplayHud _gameplayHud;
        [Required] [SerializeField] private ContainerView _containerView;
        [Required] [SerializeField] private LocalizationView _localizationView;
        
        public override void InstallBindings()
        {
            Container.Bind<GameplayHud>().FromInstance(_gameplayHud).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.Bind<ILocalizationView>().FromInstance(_localizationView).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
            Container.Bind<GameplaySceneViewFactory>().AsSingle();
            
            BindServices();
            BindCharacters();
            BindFormFactories();
            BindWeapons();
            BindBear();
            BindEnemy();
            BindUpgrades();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<NewInputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            Container.Bind<LinecastService>().AsSingle();
            Container.Bind<OverlapService>().AsSingle();
            Container.Bind<IObjectPool<BulletView>>().To<ObjectPool<BulletView>>().AsSingle();
            Container.Bind<IBulletSpawner>().To<BulletSpawner>().AsSingle();
            Container.Bind<ILocalizationService>().To<TestLocalizationService>().AsSingle();
            Container.Bind<ITurkishTranslateService>().To<TurkishTranslateService>().AsSingle();
            Container.Bind<IEnglishTranslateService>().To<EnglishTranslateService>().AsSingle();
            Container.Bind<IRussianTranslateService>().To<RussianTranslateService>().AsSingle();
        }

        private void BindFormFactories()
        {
            Container.Bind<GameplayFormServiceFactory>().AsSingle();
            Container.Bind<PauseFormPresenterFactory>().AsSingle();
            Container.Bind<HudFormPresenterFactory>().AsSingle();
            Container.Bind<UpgradeFormPresenterFactory>().AsSingle();
        }

        private void BindCharacters()
        {
            Container.Bind<CharacterViewFactory>().AsSingle();
            
            Container.Bind<CharacterMovementPresenterFactory>().AsSingle();
            Container.Bind<CharacterMovementViewFactory>().AsSingle();

            Container.Bind<CharacterAttackerPresenterFactory>().AsSingle();
            Container.Bind<CharacterAttackerViewFactory>().AsSingle();
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

        private void BindEnemy()
        {
            Container.Bind<HealthUiPresenterFactory>().AsSingle();
            Container.Bind<HealthUiFactory>().AsSingle();
            
            Container.Bind<EnemyCommonViewFactory>().AsSingle();
            Container.Bind<EnemyHealthPresenterFactory>().AsSingle();
            Container.Bind<EnemyHealthViewFactory>().AsSingle();
            Container.Bind<EnemyPresenterFactory>().AsSingle();
            Container.Bind<EnemyViewFactory>().AsSingle();
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