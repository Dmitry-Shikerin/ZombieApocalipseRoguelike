using Sources.Domain.Models.Spawners.Types;
using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class EnemySpawnPoint : View, IEnemySpawnPoint
    {
        [SerializeField] private EnemyType _enemyType;
        
        public EnemyType EnemyType => _enemyType;
        public Vector3 Position => transform.position;
    }
}