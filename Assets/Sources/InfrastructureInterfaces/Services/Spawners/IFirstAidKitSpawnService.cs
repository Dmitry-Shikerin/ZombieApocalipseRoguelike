using Sources.PresentationsInterfaces.Views.FirstAidKits;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IFirstAidKitSpawnService
    {
        IFirstAidKitView Spawn(Vector3 position);
    }
}