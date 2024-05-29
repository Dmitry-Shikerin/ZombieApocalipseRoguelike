using Sources.Domain.Models.Upgrades.Configs;
using Sources.Infrastructure.Factories.Controllers.Presenters.Abilities;
using Sources.Infrastructure.Factories.Controllers.Presenters.Weapons;
using Sources.Infrastructure.Factories.Views.Abilities;
using Sources.Infrastructure.Factories.Views.Bullets;
using Sources.Infrastructure.Factories.Views.Weapons;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.Infrastructure.Services.Spawners;
using Sources.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Bullets;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<SawLauncherAbilityUpgradeMap>()
                .FromResource("Configs/Upgrades/SawLauncherAbilityUpgradeMap")
                .AsSingle();

            Container.Bind<IObjectPool<BulletView>>().To<ObjectPool<BulletView>>().AsSingle();

            Container.Bind<IBulletSpawnService>().To<BulletSpawnService>().AsSingle();

            Container.Bind<MiniGunPresenterFactory>().AsSingle();
            Container.Bind<MiniGunViewFactory>().AsSingle();

            Container.Bind<IBulletViewFactory>().To<BulletViewFactory>().AsSingle();

            Container.Bind<SawLauncherAbilityPresenterFactory>().AsSingle();
            Container.Bind<SawLauncherAbilityViewFactory>().AsSingle();

            Container.Bind<SawLauncherPresenterFactory>().AsSingle();
            Container.Bind<SawLauncherViewFactory>().AsSingle();
        }
    }
}