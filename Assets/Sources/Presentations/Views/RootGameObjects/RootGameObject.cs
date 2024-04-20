using Sirenix.OdinInspector;
using Sources.Presentations.Views.Cameras.Points;
using Sources.Presentations.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.RootGameObjects
{
    public class RootGameObject : View
    {
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Spawners")] [Required] [ChildGameObjectsOnly] [SerializeField] 
        private EnemySpawnerView _enemySpawnerView;
        [FoldoutGroup("Spawners")] [Required] [ChildGameObjectsOnly] [SerializeField] 
        private ItemSpawnerView _itemSpawnerView;

        [Button(ButtonSizes.Large)] [FoldoutGroup("CameraPoints")] [Required] [ChildGameObjectsOnly] [SerializeField]
        private AllMapPoint _allMapPoint;
        
        public EnemySpawnerView EnemySpawnerView => _enemySpawnerView;
        public ItemSpawnerView ItemSpawnerView => _itemSpawnerView;
        
        public AllMapPoint AllMapPoint => _allMapPoint;
    }
}