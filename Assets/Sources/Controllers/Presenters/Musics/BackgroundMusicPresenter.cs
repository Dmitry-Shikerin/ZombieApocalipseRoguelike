﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Models.AudioSources;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.Views.Music;
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
            
            // _pauseService.PauseSoundActivated += OnPauseActivated;
            // _pauseService.ContinueSoundActivated += OnContinueSoundActivated;
            _volumeService.MusicVolumeChanged += OnMusicVolumeChanged;
            StartMusic(_cancellationTokenSource.Token);
        }

        public override void Disable()
        {
            // _pauseService.PauseSoundActivated -= OnPauseActivated;
            // _pauseService.ContinueSoundActivated -= OnContinueSoundActivated;
            _volumeService.MusicVolumeChanged -= OnMusicVolumeChanged;
            _cancellationTokenSource.Cancel();
        }

        private void OnPauseActivated() =>
            _backgroundMusicView.BackgroundMusicAudioSource.Pause();

        private void OnContinueSoundActivated() =>
            _backgroundMusicView.BackgroundMusicAudioSource.UnPause();

        private void OnMusicVolumeChanged() =>
            _backgroundMusicView.BackgroundMusicAudioSource.SetVolume(_volumeService.MusicVolume);

        //TODO коллекцию клипов можно брать с вьюшки?
        public async void StartMusic(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    foreach (AudioClip audioClip in _audioClipCollection.AudioClips)
                    {
                        _backgroundMusicView.BackgroundMusicAudioSource.SetClip(audioClip);
                        _backgroundMusicView.BackgroundMusicAudioSource.Play();
                        
                        await UniTask.WaitUntil(
                            () => _backgroundMusicView.BackgroundMusicAudioSource.IsPlaying == false,
                            cancellationToken: cancellationToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}