using System;
using System.Threading;
using Agava.WebUtility;
using Agava.YandexGames;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Players;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using UnityEngine;

namespace Sources.Frameworks.YandexSdcFramework.Services.AdvertisingServices
{
    public class AdvertisingService : IInterstitialAdService, IVideoAdService, IAdvertisingService
    {
        private readonly IPauseService _pauseService;

        private PlayerWallet _playerWallet;

        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _timeSpan = TimeSpan.FromSeconds(35);

        public AdvertisingService(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public bool IsAvailable { get; private set; } = true;

        public void Enable() =>
            _cancellationTokenSource = new CancellationTokenSource();

        public void Disable() =>
            _cancellationTokenSource.Cancel();

        public void Construct(PlayerWallet playerWallet) =>
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));

        public void ShowInterstitial()
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return;

            if (AdBlock.Enabled)
                return;

            if (IsAvailable == false)
            {
                Debug.Log($"Interstitial is not available. Available: {IsAvailable}");
                return;
            }

            InterstitialAd.Show(
                () =>
                {
                    _pauseService.Pause();
                    _pauseService.PauseSound();
                },
                _ =>
                {
                    _pauseService.Continue();
                    _pauseService.ContinueSound();
                    StartTimer(_cancellationTokenSource.Token);
                });
        }

        public void ShowVideo(Action onCloseCallback)
        {
            Debug.Log("ShowVideoAd");
            if (WebApplication.IsRunningOnWebGL == false)
            {
                onCloseCallback?.Invoke();

                return;
            }

            if (AdBlock.Enabled)
            {
                onCloseCallback?.Invoke();

                return;
            }

            VideoAd.Show(
                () =>
                {
                    _pauseService.Pause();
                    _pauseService.PauseSound();
                },
                () =>
                    _playerWallet.AddCoins(AdvertisingConst.CoinsAmount),
                () =>
                {
                    _pauseService.Continue();
                    _pauseService.ContinueSound();

                    onCloseCallback?.Invoke();
                });
        }

        private async void StartTimer(CancellationToken cancellationToken)
        {
            try
            {
                IsAvailable = false;
                await UniTask.Delay(_timeSpan, cancellationToken: cancellationToken);
                IsAvailable = true;
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}