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
            _formService.Hide(FormId.Save);

            _enemySpawner.CurrentWaveChanged += OnCurrentWaveChanged;
        }

        public void Exit()
        {
            _enemySpawner.CurrentWaveChanged -= OnCurrentWaveChanged;
            _cancellationTokenSource.Cancel();
        }

        public void Register(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }

        private void OnCurrentWaveChanged()
        {
            _loadService.SaveAll();
            ShowSaveForm(_cancellationTokenSource.Token);
            Debug.Log("Game saved");
        }

        private async void ShowSaveForm(CancellationToken cancellationToken)
        {
            try
            {
                _formService.Show(FormId.Save);
                await UniTask.Delay(TimeSpan.FromSeconds(5f), cancellationToken: cancellationToken);
                _formService.Hide(FormId.Save);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}