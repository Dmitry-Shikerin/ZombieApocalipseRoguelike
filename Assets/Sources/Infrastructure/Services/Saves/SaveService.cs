using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Constants;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.Frameworks.UiFramework.Presentation.Views.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Saves;

namespace Sources.Infrastructure.Services.Saves
{
    public class SaveService : ISaveService
    {
        private readonly ILoadService _loadService;
        private readonly IFormService _formService; 
        private readonly TimeSpan _showedFormDelay = TimeSpan.FromSeconds(SaveConst.ShowedFormDelay);
        
        private IEnemySpawner _enemySpawner;
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

        public void Register(IEnemySpawner enemySpawner) =>
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));

        private void OnCurrentWaveChanged()
        {
            _loadService.SaveAll();
            ShowSaveForm(_cancellationTokenSource.Token);
        }

        private async void ShowSaveForm(CancellationToken cancellationToken)
        {
            try
            {
                _formService.Show(FormId.Save);
                await UniTask.Delay(_showedFormDelay, cancellationToken: cancellationToken);
                _formService.Hide(FormId.Save);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}