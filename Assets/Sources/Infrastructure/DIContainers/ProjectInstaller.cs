using Sources.Infrastructure.Services.SceneLoaderServices;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
        }
    }
}