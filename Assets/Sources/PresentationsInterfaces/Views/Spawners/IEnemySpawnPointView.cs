using Sources.Domain.Enemies.Types;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnPointView
    {
        EnemyType EnemyType { get; }
        Vector3 Position { get; }
    }
}