using System;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.InfrastructureInterfaces.Services;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UiFramework.Forms.Types;
using Sources.Presentations.Views.Forms.Gameplay;
using UnityEngine;

namespace Sources.Infrastructure.Services.LevelCompleteds
{
    public class LevelCompletedService : ILevelCompletedService
    {
        private readonly IFormService _formService;
        private KillEnemyCounter _killEnemyCounter;
        private EnemySpawner _enemySpawner;

        public LevelCompletedService(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enable()
        {
            _killEnemyCounter.KillZombiesCountChanged += OnKillZombiesCountChanged;
        }

        public void Disable()
        {
            _killEnemyCounter.KillZombiesCountChanged -= OnKillZombiesCountChanged;
        }

        private void OnKillZombiesCountChanged()
        {
            if (_killEnemyCounter.KillZombies == _enemySpawner.SumEnemies + _enemySpawner.BossesInLevel)
            {
                _formService.Show(FormId.LevelCompleted);
                Debug.Log("Show level completed form");
            }
        }

        public void Register(KillEnemyCounter killEnemyCounter, EnemySpawner enemySpawner)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }
    }
}