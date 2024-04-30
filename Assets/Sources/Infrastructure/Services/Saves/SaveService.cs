using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Saves;
using UnityEngine;

namespace Sources.Infrastructure.Services.Saves
{
    public class SaveService : ISaveService
    {
        private readonly ILoadService _loadService;
        private readonly IFormService _formService;
        private KillEnemyCounter _killEnemyCounter;
        private EnemySpawner _enemySpawner;
        
        private CancellationTokenSource _cancellationTokenSource;
        
        public SaveService(
            ILoadService loadService,
            IFormService formService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enter(object payload = null)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _formService.HideCustomContainer(CustomFormId.Save);
            
            _killEnemyCounter.KillZombiesCountChanged += OnKillEnemyCounterChanged;
        }

        public void Exit()
        {
            _cancellationTokenSource.Cancel();
        }

        public void Register(KillEnemyCounter killEnemyCounter, EnemySpawner enemySpawner)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }

        private void OnKillEnemyCounterChanged()
        {
            int sum = 0;
            
            for (int i = 0; i < _enemySpawner.EnemyInWave.Count; i++)
            {
                sum += _enemySpawner.EnemyInWave[i];
                
                if (_killEnemyCounter.KillZombies == sum)
                {
                    _loadService.SaveAll();
                    ShowSaveForm(_cancellationTokenSource.Token);
                    Debug.Log("Game saved");
                    return;
                }
            }
        }

        private async void ShowSaveForm(CancellationToken cancellationToken)
        {
            try
            {
                _formService.ShowCustomContainer(CustomFormId.Save);
                await UniTask.Delay(TimeSpan.FromSeconds(5f), cancellationToken: cancellationToken);
                _formService.HideCustomContainer(CustomFormId.Save);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}