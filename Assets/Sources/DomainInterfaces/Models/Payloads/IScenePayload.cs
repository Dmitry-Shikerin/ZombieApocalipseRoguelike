namespace Sources.DomainInterfaces.Payloads
{
    public interface IScenePayload
    {
        string SceneId { get; }
        bool CanLoad { get; }
    }
}