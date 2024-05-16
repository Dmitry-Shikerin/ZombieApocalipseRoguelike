﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Models.Constants;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.PresentationsInterfaces.Views.InterstitialShowers;
using UnityEngine;

namespace Sources.Controllers.Presenters.InterstitialShowers
{
    public class InterstitialShowerPresenter : PresenterBase
    {
        private readonly IEnemySpawner _enemySpawner;
        private readonly IInterstitialShowerView _view;
        private readonly IInterstitialAdService _interstitialAdService;
        private readonly IFormService _formService;

        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _timerTimeSpan = TimeSpan.FromSeconds(AdvertisingConst.Delay);

        public InterstitialShowerPresenter(
            IEnemySpawner enemySpawner, 
            IInterstitialShowerView view,
            IInterstitialAdService interstitialAdService,
            IFormService formService)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _interstitialAdService = interstitialAdService ??
                                     throw new ArgumentNullException(nameof(interstitialAdService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _enemySpawner.CurrentWaveChanged += OnCurrentWaveChanged;
            _formService.Hide(FormId.ShowAd);
        }

        public override void Disable()
        {
            _cancellationTokenSource.Cancel();
            _enemySpawner.CurrentWaveChanged -= OnCurrentWaveChanged;
        }
        
        private void OnCurrentWaveChanged()
        {
            Debug.Log("Show interstitial");
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
            }
        }
        
        private async UniTask ShowTimerAsync(CancellationToken cancellationToken)
        {
            for (int i = 3; i > 0 ; i--)
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