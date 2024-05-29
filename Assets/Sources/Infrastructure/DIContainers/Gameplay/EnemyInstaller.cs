using Sources.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Infrastructure.Factories.Controllers.Presenters.Enemies;
using Sources.Infrastructure.Factories.Controllers.Presenters.Enemies.Base;
using Sources.Infrastructure.Factories.Controllers.Presenters.Enemies.Bosses;
using Sources.Infrastructure.Factories.Views.Commons;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.Infrastructure.Factories.Views.Enemies.Base;
using Sources.Infrastructure.Factories.Views.Enemies.Bosses;
using Sources.Infrastructure.Factories.Views.ExplosionBodyBloodyViews;
using Sources.Infrastructure.Services.Enemies;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.Infrastructure.Services.Spawners;
using Sources.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Factories.Views.ExplosionBodyBloodyViews;
using Sources.InfrastructureInterfaces.Services.Enemies;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Enemies.Base;
using Sources.Presentations.Views.Enemies.Bosses;
using Sources.Presentations.Views.ExplosionBodyBloodies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CustomCollection<IEnemyView>>().AsSingle();

            Container.Bind<IObjectPool<EnemyView>>().To<ObjectPool<EnemyView>>().AsSingle();
            Container.Bind<IObjectPool<BossEnemyView>>().To<ObjectPool<BossEnemyView>>().AsSingle();
            Container.Bind<IObjectPool<ExplosionBodyBloodyView>>().To<ObjectPool<ExplosionBodyBloodyView>>().AsSingle();

            Container.Bind<IExplosionBodyBloodySpawnService>().To<ExplosionBodyBloodySpawnService>().AsSingle();
            Container.Bind<IEnemySpawnService>().To<EnemySpawnService>().AsSingle();
            Container.Bind<IBossEnemySpawnService>().To<BossEnemySpawnService>().AsSingle();
            Container.Bind<IEnemyAttackService>().To<EnemyAttackService>().AsSingle();

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
    }
}