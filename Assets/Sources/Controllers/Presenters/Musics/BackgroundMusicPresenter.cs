using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Models.AudioSources;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.PresentationsInterfaces.UI.AudioSources;
using Sources.PresentationsInterfaces.Views.Music;
using UnityEngine;

namespace Sources.Controllers.Presenters.Musics
{
    public class BackgroundMusicPresenter : PresenterBase
    {
        private readonly AudioClipCollection _audioClipCollection;
        private readonly IBackgroundMusicView _backgroundMusicView;
        private readonly IVolumeService _volumeService;
        private readonly IPauseService _pauseService;

        private CancellationTokenSource _cancellationTokenSource;
        private float _savedTime;

        public BackgroundMusicPresenter(
            AudioClipCollection audioClipCollection, 
            IBackgroundMusicView backgroundMusicView,
            IVolumeService volumeService,
            IPauseService pauseService)
        {
            _audioClipCollection = audioClipCollection 
                ? audioClipCollection 
                : throw new ArgumentNullException(nameof(audioClipCollection));
            _backgroundMusicView = backgroundMusicView ?? throw new ArgumentNullException(nameof(backgroundMusicView));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _pauseService.PauseSoundActivated += OnPauseSoundActivated;
            _pauseService.ContinueSoundActivated += OnContinueSoundActivated;
            _volumeService.MusicVolumeChanged += OnMusicVolumeChanged;
            StartMusic(_cancellationTokenSource.Token);
        }

        public override void Disable()
        {
            _pauseService.PauseSoundActivated -= OnPauseSoundActivated;
            _pauseService.ContinueSoundActivated -= OnContinueSoundActivated;
            _volumeService.MusicVolumeChanged -= OnMusicVolumeChanged;
            _cancellationTokenSource.Cancel();
        }

        private void OnPauseSoundActivated()
        {
            _savedTime = _backgroundMusicView.BackgroundMusicAudioSource.Time;
            _backgroundMusicView.BackgroundMusicAudioSource.Pause();
        }

        private void OnContinueSoundActivated()
        {
            _backgroundMusicView.BackgroundMusicAudioSource.SetTime(_savedTime);
            _backgroundMusicView.BackgroundMusicAudioSource.UnPause();
        }

        private void OnMusicVolumeChanged() =>
            _backgroundMusicView.BackgroundMusicAudioSource.SetVolume(_volumeService.MusicVolume);

        private async void StartMusic(CancellationToken cancellationToken)
        {
            IAudioSourceView audioSourceView = _backgroundMusicView.BackgroundMusicAudioSource;
            
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    foreach (AudioClip audioClip in _audioClipCollection.AudioClips)
                    {
                        audioSourceView.SetClip(audioClip);
                        audioSourceView.Play();
                        await WaitEnd(audioClip, audioSourceView, cancellationToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask WaitEnd(
            AudioClip audioClip, 
            IAudioSourceView audioSourceView, 
            CancellationToken cancellationToken)
        {
            //TODO Approximately is not working
            while (audioSourceView.Time + 0.15f < audioClip.length)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), 
                    ignoreTimeScale: true, 
                    cancellationToken: cancellationToken);
            }
        }
    }
}