using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Infrastructure.Factories.Controllers.Players;
using Sources.Infrastructure.Factories.Controllers.Presenters.Characters;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Players;
using Sources.Infrastructure.Services.Characters;
using Sources.Infrastructure.Services.Providers;
using Sources.InfrastructureInterfaces.Services.Characters;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICharacterMovementService>().To<CharacterMovementService>().AsSingle();
            Container.Bind<IEnemyIndicatorService>().To<EnemyIndicatorService>().AsSingle();
            
            Container.Bind<PlayerWalletProvider>().AsSingle();
            
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
        }
    }
}