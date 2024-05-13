using Sources.Infrastructure.Factories.Controllers.Presenters.Bears;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Services.Bears;
using Sources.InfrastructureInterfaces.Services.Bears;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class BearInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBearMovementService>().To<BearMovementService>().AsSingle();
            
            Container.Bind<BearPresenterFactory>().AsSingle();
            Container.Bind<BearViewFactory>().AsSingle();
        }
    }
}