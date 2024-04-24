using Sources.DomainInterfaces.Payloads;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes
{
    public interface ILoadSceneService
    {
        void Load(IScenePayload scenePayload);
    }
}