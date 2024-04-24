using System;
using Sources.Controllers.Musics;
using Sources.Domain.Models.AudioSources;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.Views.Music;

namespace Sources.Infrastructure.Factories.Controllers.Musics
{
    public class BackgroundMusicPresenterFactory
    {
        private readonly IVolumeService _volumeService;
        private readonly AudioClipCollection _audioClipCollection;

        public BackgroundMusicPresenterFactory(
            AudioClipCollection audioClipCollection,
            IVolumeService volumeService)
        {
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _audioClipCollection = audioClipCollection 
                ? audioClipCollection 
                : throw new ArgumentNullException(nameof(audioClipCollection));
        }

        public BackgroundMusicPresenter Create(IBackgroundMusicView backgroundMusicView)
        {
            return new BackgroundMusicPresenter(
                _audioClipCollection, 
                backgroundMusicView,
                _volumeService);
        }
    }
}