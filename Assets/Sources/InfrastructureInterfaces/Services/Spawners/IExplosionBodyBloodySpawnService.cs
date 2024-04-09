using Sources.PresentationsInterfaces.Views.ExplosionBodyBloodies;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IExplosionBodyBloodySpawnService
    {
        public IExplosionBodyBloodyView Spawn(Vector3 position);
    }
}