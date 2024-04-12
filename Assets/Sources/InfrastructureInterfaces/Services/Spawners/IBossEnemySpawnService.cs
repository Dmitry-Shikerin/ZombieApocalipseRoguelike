using Sources.Domain.Gameplay;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IBossEnemySpawnService
    {
        IBossEnemyView Spawn(KillEnemyCounter killEnemyCounter, Vector3 position);
    }
}