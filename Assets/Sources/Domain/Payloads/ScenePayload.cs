using Sources.DomainInterfaces.Payloads;

namespace Sources.Domain.Payloads
{
    public class ScenePayload : IScenePayload
    {
        public ScenePayload(string sceneId, bool canLoad)
        {
            SceneId = sceneId;
            CanLoad = canLoad;
        }

        public string SceneId { get; }
        public bool CanLoad { get; }
    }
}