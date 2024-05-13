using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.InfrastructureInterfaces.Services.Interstitials;
using UnityEngine;

namespace Sources.Infrastructure.Services.Interstitials
{
    public class InterstitialShowerService : IInterstitialShowerService
    {
        private readonly IInterstitialAdService _interstitialAdService;
        private IEnemySpawner _enemySpawner;
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _advertisementTimeSpan = TimeSpan.FromMinutes(InterstitialConst.ShowDelay);
        private TimeSpan _timerTimeSpan = TimeSpan.FromSeconds(AdvertisingConst.Delay);

        public InterstitialShowerService(IInterstitialAdService interstitialAdService)
        {
            _interstitialAdService = interstitialAdService ??
                                     throw new ArgumentNullException(nameof(interstitialAdService));
        }

        public async void Enter(object payload = null)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _enemySpawner.CurrentWaveChanged += OnCurrentWaveChanged;
        }

        public void Exit()
        {
            _cancellationTokenSource.Cancel();
            _enemySpawner.CurrentWaveChanged -= OnCurrentWaveChanged;
        }

        public void Register(IEnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }

        private void OnCurrentWaveChanged()
        {
            Debug.Log("Show interstitial");
            _interstitialAdService.ShowInterstitial();
        }

         //private async UniTask ShowInterstitialAsync(CancellationToken cancellationToken)
         //{
         //    try
         //    {
         //        while (cancellationToken.IsCancellationRequested == false)
         //        {
         //            await UniTask.Delay(_advertisementTimeSpan, cancellationToken: cancellationToken);
        //
         //            EnableTimer();
        //
         //            await ShowTimerAsync(cancellationToken);
        //
         //            DisableTimer();
         //        }
         //    }
         //    catch (OperationCanceledException)
         //    {
         //    }
         //}
        
         //private async UniTask ShowTimerAsync(CancellationToken cancellationToken)
         //{
         //    //TODO перевести текст
         //    _viewContainer.Title.SetText(AdvertisingConstant.ContentText);
         //    _viewContainer.Timer.SetText("3");
        //
         //    await UniTask.Delay(_timerTimeSpan, cancellationToken: cancellationToken);
         //    _viewContainer.Timer.SetText("2");
        //
         //    await UniTask.Delay(_timerTimeSpan, cancellationToken: cancellationToken);
         //    _viewContainer.Timer.SetText("1");
        //
         //    await UniTask.Delay(_timerTimeSpan, cancellationToken: cancellationToken);
        //
         //    _interstitialAdService.ShowInterstitial();
         //}
        //
         //private void DisableTimer()
         //{
         //    _viewContainer.Hide();
        //
         //    _viewContainer.Title.Disable();
         //    _viewContainer.Timer.Disable();
         //}
        //
         //private void EnableTimer()
         //{
         //    _viewContainer.Show();
        //
         //    _viewContainer.Title.Enable();
         //    _viewContainer.Timer.Enable();
         //}
    }
}