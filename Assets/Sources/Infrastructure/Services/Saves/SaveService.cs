using System;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Saves;
using UnityEngine;

namespace Sources.Infrastructure.Services.Saves
{
    public class SaveService : ISaveService
    {
        private readonly ILoadService _loadService;
        private KillEnemyCounter _killEnemyCounter;
        private EnemySpawner _enemySpawner;

        public SaveService(ILoadService loadService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public void Enter(object payload = null)
        {
            _killEnemyCounter.KillZombiesCountChanged += OnKillEnemyCounterChanged;
        }

        public void Exit()
        {
        }

        private void OnKillEnemyCounterChanged()
        {
            for (int i = 0; i < _enemySpawner.EnemyInWave.Count; i++)
            {
                if(_killEnemyCounter.KillZombies < _enemySpawner.EnemyInWave[i])
                    return;

                if (_killEnemyCounter.KillZombies == _enemySpawner.EnemyInWave[i])
                {
                    _loadService.SaveAll();
                    Debug.Log("Game saved");
                    //TODO сделать формочку о том что игра сохранена
                    return;
                }
            }
        }

        public void Register(KillEnemyCounter killEnemyCounter, EnemySpawner enemySpawner)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }
    }
}