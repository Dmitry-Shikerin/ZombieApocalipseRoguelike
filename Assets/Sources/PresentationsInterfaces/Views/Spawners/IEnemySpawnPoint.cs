using Sources.Domain.Spawners.Types;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnPoint
    {
        EnemyType EnemyType { get; }
        Vector3 Position { get; }
    }
}