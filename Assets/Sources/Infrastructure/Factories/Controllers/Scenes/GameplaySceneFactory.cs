using Cysharp.Threading.Tasks;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;

namespace Sources.Infrastructure.Factories.Controllers.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene();
        }
    }
}