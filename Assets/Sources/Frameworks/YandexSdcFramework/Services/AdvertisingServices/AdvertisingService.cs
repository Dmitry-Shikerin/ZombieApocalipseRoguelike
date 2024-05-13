using System;
using Agava.WebUtility;
using Agava.YandexGames;
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

        public AdvertisingService(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public void ShowInterstitial()
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return;

            if (AdBlock.Enabled)
                return;

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

        public void Construct(PlayerWallet playerWallet) =>
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
    }
}