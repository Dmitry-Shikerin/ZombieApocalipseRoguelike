using System.Collections.Generic;
using UnityEngine;

namespace Sources.Domain.Models.Spawners.Configs.Containers
{
    [CreateAssetMenu(
        menuName = "Configs/Spawners/EnemySpawnerConfigContainer",
        fileName = "EnemySpawnerConfigContainer",
        order = 51)]
    public class EnemySpawnerConfigContainer : ScriptableObject
    {
        [SerializeField] private List<EnemySpawnerConfig> _configs;

        public IReadOnlyList<EnemySpawnerConfig> Configs => _configs;
    }
}