using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
        }
    }
}