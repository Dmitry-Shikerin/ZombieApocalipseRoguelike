using System;
using System.Threading;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.InfrastructureInterfaces.Services.Interstitials;
using UnityEngine;

namespace Sources.Infrastructure.Services.Interstitials
{
    public class InterstitialShowerService : IInterstitialShowerService
    {
        private readonly IInterstitialAdService _interstitialAdService;
        private KillEnemyCounter _killEnemyCounter;
        private EnemySpawner _enemySpawner;
        private TimeSpan _advertisementTimeSpan;
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _timerTimeSpan;
        
        public InterstitialShowerService(IInterstitialAdService interstitialAdService)
        {
            _interstitialAdService = interstitialAdService ?? 
                                     throw new ArgumentNullException(nameof(interstitialAdService));
        }

        public async void Enter(object payload = null)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _advertisementTimeSpan = TimeSpan.FromMinutes(InterstitialConstant.ShowDelay);
            _timerTimeSpan = TimeSpan.FromSeconds(AdvertisingConstant.Delay);

            _killEnemyCounter.KillZombiesCountChanged += OnKillEnemyCounterChanged;
        }

        public void Exit()
        {
            _killEnemyCounter.KillZombiesCountChanged -= OnKillEnemyCounterChanged;
        }

        public void Register(KillEnemyCounter killEnemyCounter, EnemySpawner enemySpawner)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }

        //TODO вынести этот метов в отдельный сервис 
        //TODO он используется здесь в энеми спавнере и в сервисе сохранения
        private void OnKillEnemyCounterChanged()
        {
            int sum = 0;
            
            for (int i = 0; i < _enemySpawner.EnemyInWave.Count; i++)
            {
                sum += _enemySpawner.EnemyInWave[i];
                
                if (_killEnemyCounter.KillZombies == sum)
                {
                    //TODO добавить 
                    _interstitialAdService.ShowInterstitial();
                    Debug.Log("Show interstitial");
                    return;
                }
            }
        }
        
        // private async UniTask ShowInterstitialAsync(CancellationToken cancellationToken)
        // {
        //     try
        //     {
        //         while (cancellationToken.IsCancellationRequested == false)
        //         {
        //             await UniTask.Delay(_advertisementTimeSpan, cancellationToken: cancellationToken);
        //
        //             EnableTimer();
        //
        //             await ShowTimerAsync(cancellationToken);
        //
        //             DisableTimer();
        //         }
        //     }
        //     catch (OperationCanceledException)
        //     {
        //     }
        // }
        //
        // private async UniTask ShowTimerAsync(CancellationToken cancellationToken)
        // {
        //     //TODO перевести текст
        //     _viewContainer.Title.SetText(AdvertisingConstant.ContentText);
        //     _viewContainer.Timer.SetText("3");
        //
        //     await UniTask.Delay(_timerTimeSpan, cancellationToken: cancellationToken);
        //     _viewContainer.Timer.SetText("2");
        //
        //     await UniTask.Delay(_timerTimeSpan, cancellationToken: cancellationToken);
        //     _viewContainer.Timer.SetText("1");
        //
        //     await UniTask.Delay(_timerTimeSpan, cancellationToken: cancellationToken);
        //
        //     _interstitialAdService.ShowInterstitial();
        // }
        //
        // private void DisableTimer()
        // {
        //     _viewContainer.Hide();
        //
        //     _viewContainer.Title.Disable();
        //     _viewContainer.Timer.Disable();
        // }
        //
        // private void EnableTimer()
        // {
        //     _viewContainer.Show();
        //
        //     _viewContainer.Title.Enable();
        //     _viewContainer.Timer.Enable();
        // }
    }
}