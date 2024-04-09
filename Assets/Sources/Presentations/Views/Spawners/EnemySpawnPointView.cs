using Sources.Domain.Enemies.Types;
using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class EnemySpawnPointView : View, IEnemySpawnPointView
    {
        [SerializeField] private EnemyType _enemyType;
        
        public EnemyType EnemyType => _enemyType;
        public Vector3 Position => transform.position;
    }
}