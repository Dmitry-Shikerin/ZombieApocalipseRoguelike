using Sirenix.OdinInspector;
using Sources.Presentations.Views.Cameras.Points;
using Sources.Presentations.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.RootGameObjects
{
    public class RootGameObject : View
    {
        [FoldoutGroup("Spawners")] [Required] [ChildGameObjectsOnly]
        [SerializeField] private EnemySpawnerView _enemySpawnerView;
        [FoldoutGroup("Spawners")] [Required] [ChildGameObjectsOnly]
        [SerializeField] private ItemSpawnerView _itemSpawnerView;

        [FoldoutGroup("SpawnPoints")] [Required] [ChildGameObjectsOnly]
        [SerializeField] private CharacterSpawnPoint _characterSpawnPoint;
        [FoldoutGroup("SpawnPoints")] [Required] [ChildGameObjectsOnly]
        [SerializeField] private BearSpawnPoint _bearSpawnPoint;

        [FoldoutGroup("CameraPoints")] [Required] [ChildGameObjectsOnly]
        [SerializeField] private AllMapPoint _allMapPoint;

        public EnemySpawnerView EnemySpawnerView => _enemySpawnerView;

        public ItemSpawnerView ItemSpawnerView => _itemSpawnerView;

        public AllMapPoint AllMapPoint => _allMapPoint;

        public CharacterSpawnPoint CharacterSpawnPoint => _characterSpawnPoint;

        public BearSpawnPoint BearSpawnPoint => _bearSpawnPoint;
    }
}