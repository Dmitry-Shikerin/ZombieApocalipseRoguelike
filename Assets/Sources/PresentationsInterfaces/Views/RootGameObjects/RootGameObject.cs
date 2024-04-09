using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Spawners;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.RootGameObjects
{
    public class RootGameObject : View
    {
        [Required] [ChildGameObjectsOnly] [SerializeField] private EnemySpawnerView _enemySpawnerView;
        
        public EnemySpawnerView EnemySpawnerView => _enemySpawnerView;
    }
}