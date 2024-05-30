using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Spawners.Configs.Containers;
using Sources.Infrastructure.Factories.Controllers.Presenters.Spawners;
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Services.EnemySpawners;
using Sources.InfrastructureInterfaces.Services.EnemySpawners;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class SpawnersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EnemySpawnerConfigContainer>()
                .FromResource(PrefabPath.EnemySpawnerConfigContainer)
                .AsSingle();

            Container.Bind<IEnemySpawnerConfigCollectionService>()
                .To<EnemySpawnerConfigCollectionService>().AsSingle();

            Container.Bind<EnemySpawnPresenterFactory>().AsSingle();
            Container.Bind<EnemySpawnViewFactory>().AsSingle();

            Container.Bind<ItemSpawnerPresenterFactory>().AsSingle();
            Container.Bind<ItemSpawnerViewFactory>().AsSingle();
        }
    }
}