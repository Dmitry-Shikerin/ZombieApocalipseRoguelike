using Sources.DomainInterfaces.Payloads;

namespace Sources.Domain.Models.Payloads
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