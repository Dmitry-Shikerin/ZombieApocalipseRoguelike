using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Domain.Models.Spawners.Configs
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Configs/EnemySpawnerConfig", order = 51)]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [SerializeField] private string _sceneId;
        [SerializeField] private List<int> _enemyInWave;
        [SerializeField] private List<int> _spawnDelays;
        
        public string SceneId => _sceneId;
        public IReadOnlyList<int> EnemyInWave => _enemyInWave;
        public IReadOnlyList<int> SpawnDelays => _spawnDelays;
    }
}