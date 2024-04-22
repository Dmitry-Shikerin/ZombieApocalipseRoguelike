using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.AudioSources;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.Views.Music;
using UnityEngine;

namespace Sources.Controllers.Musics
{
    public class BackgroundMusicPresenter : PresenterBase
    {
        private readonly AudioClipCollection _audioClipCollection;
        private readonly IBackgroundMusicView _backgroundMusicView;
        private readonly IVolumeService _volumeService;

        private CancellationTokenSource _cancellationTokenSource;

        public BackgroundMusicPresenter(
            AudioClipCollection audioClipCollection, 
            IBackgroundMusicView backgroundMusicView,
            IVolumeService volumeService)
        {
            _audioClipCollection = audioClipCollection 
                ? audioClipCollection 
                : throw new ArgumentNullException(nameof(audioClipCollection));
            _backgroundMusicView = backgroundMusicView ?? throw new ArgumentNullException(nameof(backgroundMusicView));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            _volumeService.VolumeChanged += OnVolumeChanged;
            StartMusic(_cancellationTokenSource.Token);
        }

        public override void Disable()
        {
            _volumeService.VolumeChanged -= OnVolumeChanged;
            _cancellationTokenSource.Cancel();
        }

        private void OnVolumeChanged() =>
            _backgroundMusicView.BackgroundMusicAudioSource.SetVolume(_volumeService.Volume);

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