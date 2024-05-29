using Sources.Infrastructure.Factories.Domain.Data;
using Sources.Infrastructure.Services.LoadServices.Collectors;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.LoadServices.Collectors;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Common
{
    public class DtoFactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMapperCollector>().To<MapperCollector>().AsSingle();

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
            Container.Bind<IScoreCounterDtoMapper>().To<ScoreCounterDtoMapper>().AsSingle();
        }
    }
}