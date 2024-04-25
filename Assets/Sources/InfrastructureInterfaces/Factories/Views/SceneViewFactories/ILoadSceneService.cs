using Sources.DomainInterfaces.Payloads;

namespace Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories
{
    public interface ILoadSceneService
    {
        void Load(IScenePayload scenePayload);
    }
}