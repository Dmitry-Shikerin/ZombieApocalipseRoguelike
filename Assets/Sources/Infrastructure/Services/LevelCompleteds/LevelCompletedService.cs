using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Services;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.Presentations.Views.Forms.Gameplay;
using UnityEngine;

namespace Sources.Infrastructure.Services.LevelCompleteds
{
    public class LevelCompletedService : ILevelCompletedService
    {
        private readonly IFormService _formService;
        private readonly IEntityRepository _entityRepository;
        private readonly ILoadService _loadService;
        private KillEnemyCounter _killEnemyCounter;
        private EnemySpawner _enemySpawner;

        public LevelCompletedService(
            IFormService formService,
            IEntityRepository entityRepository,
            ILoadService loadService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
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
            if (_killEnemyCounter.KillZombies < _enemySpawner.SumEnemies + _enemySpawner.BossesInLevel)
                return;

            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            Debug.Log("Saved level: " + savedLevel.SavedLevelId);
            Level level = _entityRepository.Get<Level>(savedLevel.SavedLevelId);
            level.Complete();
            Debug.Log($"Current level : {level.Id}, is completed: {level.IsCompleted}");
            _loadService.Save(level);
            _loadService.ClearAll();
            _formService.Show(FormId.LevelCompleted);
        }

        public void Register(KillEnemyCounter killEnemyCounter, EnemySpawner enemySpawner)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }
    }
}