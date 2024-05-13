using Sources.Domain.Models.Gameplay;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IEnemySpawnService
    {
        IEnemyView Spawn(KillEnemyCounter killEnemyCounter, Vector3 position);
    }
}