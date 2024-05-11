using Sources.Infrastructure.Services.SceneLoaderServices;
using Sources.Infrastructure.Services.Volumes;
using Sources.InfrastructureInterfaces.Services.SceneLoaderService;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
            Container.Bind<IVolumeService>().To<VolumeService>().AsSingle();
        }
    }
}