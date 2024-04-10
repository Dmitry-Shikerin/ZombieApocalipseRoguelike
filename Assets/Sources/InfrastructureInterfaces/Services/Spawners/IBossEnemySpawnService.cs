using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IBossEnemySpawnService
    {
        IBossEnemyView Spawn(Vector3 position);
    }
}