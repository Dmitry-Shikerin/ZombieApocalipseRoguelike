using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Constants;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.DomainInterfaces.Models.Upgrades;
using Sources.Frameworks.UiFramework.Presentation.Views.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdvertisingServices;
using Sources.PresentationsInterfaces.Views.InterstitialShowers;

namespace Sources.Controllers.Presenters.InterstitialShowers
{
    public class InterstitialShowerPresenter : PresenterBase
    {
        private readonly IEnemySpawner _enemySpawner;
        private readonly IUpgradeController _upgradeController;
        private readonly IInterstitialShowerView _view;
        private readonly IInterstitialAdService _interstitialAdService;
        private readonly IFormService _formService;

        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _timerTimeSpan = TimeSpan.FromSeconds(AdvertisingConst.Delay);

        public InterstitialShowerPresenter(
            IEnemySpawner enemySpawner,
            IUpgradeController upgradeController,
            IInterstitialShowerView view,
            IInterstitialAdService interstitialAdService,
            IFormService formService)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _upgradeController = upgradeController ?? throw new ArgumentNullException(nameof(upgradeController));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _interstitialAdService = interstitialAdService ??
                                     throw new ArgumentNullException(nameof(interstitialAdService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        private bool CanShow => _enemySpawner.CurrentWave < _enemySpawner.EnemyInWave.Count;

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _enemySpawner.CurrentWaveChanged += OnCurrentWaveChanged;
            _upgradeController.UpgradeFormShowed += OnUpgradeFormShowed;
            _formService.Hide(FormId.ShowAd);
        }

        public override void Disable()
        {
            _cancellationTokenSource.Cancel();
            _enemySpawner.CurrentWaveChanged -= OnCurrentWaveChanged;
            _upgradeController.UpgradeFormShowed -= OnUpgradeFormShowed;
        }

        private void OnUpgradeFormShowed()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void OnCurrentWaveChanged()
        {
            if (CanShow == false)
                return;

            ShowInterstitialAsync(_cancellationTokenSource.Token);
        }

        private async void ShowInterstitialAsync(CancellationToken cancellationToken)
        {
            try
            {
                EnableTimer();
                await ShowTimerAsync(cancellationToken);
                DisableTimer();
            }
            catch (OperationCanceledException)
            {
                DisableTimer();
                await Delay(cancellationToken);
                OnCurrentWaveChanged();
            }
        }

        private async UniTask Delay(CancellationToken cancellationToken)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask ShowTimerAsync(CancellationToken cancellationToken)
        {
            for (int i = 3; i > 0; i--)
            {
                _view.TimerText.SetText($"{i}");
                await UniTask.Delay(_timerTimeSpan, cancellationToken: cancellationToken);
            }

            _interstitialAdService.ShowInterstitial();
        }

        private void DisableTimer()
        {
            _formService.Hide(FormId.ShowAd);
            _view.TimerText.Disable();
        }

        private void EnableTimer()
        {
            _formService.Show(FormId.ShowAd);
            _view.TimerText.Enable();
        }
    }
}