using Sources.Infrastructure.Factories.Controllers.Gameplay;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Services.GameOvers;
using Sources.Infrastructure.Services.Interstitials;
using Sources.Infrastructure.Services.LevelCompleteds;
using Sources.Infrastructure.Services.PauseServices;
using Sources.Infrastructure.Services.Saves;
using Sources.Infrastructure.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.Interstitials;
using Sources.InfrastructureInterfaces.Services.LevelCompleteds;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class GameplayServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInterstitialShowerService>().To<InterstitialShowerService>().AsSingle();
            Container.Bind<ISaveService>().To<SaveService>().AsSingle();
            Container.Bind<ILevelCompletedService>().To<LevelCompletedService>().AsSingle();
            Container.Bind<ITutorialService>().To<TutorialService>().AsSingle();
            Container.Bind<IPauseService>().To<PauseService>().AsSingle();
            Container.Bind<IGameOverService>().To<GameOverService>().AsSingle();
            
            Container.Bind<KillEnemyCounterPresenterFactory>().AsSingle();
            Container.Bind<KillEnemyCounterViewFactory>().AsSingle();
        }
    }
}