using System;
using JetBrains.Annotations;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.LevelCompleteds;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Repositories;
using UnityEngine;

namespace Sources.Infrastructure.Services.LevelCompleteds
{
    public class LevelCompletedService : ILevelCompletedService
    {
        private readonly IFormService _formService;
        private readonly IEntityRepository _entityRepository;
        private readonly ILoadService _loadService;
        private readonly IInterstitialAdService _interstitialAdService;
        private IKillEnemyCounter _killEnemyCounter;
        private IEnemySpawner _enemySpawner;

        public LevelCompletedService(
            IFormService formService,
            IEntityRepository entityRepository,
            ILoadService loadService,
            IInterstitialAdService interstitialAdService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _interstitialAdService = interstitialAdService ?? throw new ArgumentNullException(nameof(interstitialAdService));
        }
        
        private bool IsCompleted => _killEnemyCounter.KillZombies >= _enemySpawner.SumAllEnemies;

        public void Enable()
        {
            _killEnemyCounter.KillZombiesCountChanged += OnKillZombiesCountChanged;
        }

        public void Disable()
        {
            _killEnemyCounter.KillZombiesCountChanged -= OnKillZombiesCountChanged;
        }

        public void Register(IKillEnemyCounter killEnemyCounter, IEnemySpawner enemySpawner)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }

        private void OnKillZombiesCountChanged()
        {
            if (_killEnemyCounter.KillZombies < _enemySpawner.SumAllEnemies)
                return;

            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            // Debug.Log("Saved level: " + savedLevel.SavedLevelId);
            Level level = _entityRepository.Get<Level>(savedLevel.SavedLevelId);
            level.Complete();
            // Debug.Log($"Current level : {level.Id}, is completed: {level.IsCompleted}");
            _loadService.Save(level);
            _loadService.ClearAll();
            _formService.Show(FormId.LevelCompleted);
            _interstitialAdService.ShowInterstitial();
        }
    }
}