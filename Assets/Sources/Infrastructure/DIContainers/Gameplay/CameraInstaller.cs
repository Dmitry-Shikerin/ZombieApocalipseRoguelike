using Sources.Infrastructure.Factories.Controllers.Presenters.Cameras;
using Sources.Infrastructure.Factories.Views.Cameras;
using Sources.Infrastructure.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICameraService>().To<CameraService>().AsSingle();
            Container.Bind<CameraPresenterFactory>().AsSingle();
            Container.Bind<CameraViewFactory>().AsSingle();
        }
    }
}