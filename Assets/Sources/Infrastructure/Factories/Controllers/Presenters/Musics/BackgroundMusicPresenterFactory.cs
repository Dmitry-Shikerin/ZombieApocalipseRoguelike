using System;
using Sources.Controllers.Presenters.Musics;
using Sources.Domain.Models.AudioSources;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.Views.Music;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Musics
{
    public class BackgroundMusicPresenterFactory
    {
        private readonly IVolumeService _volumeService;
        private readonly IPauseService _pauseService;
        private readonly AudioClipCollection _audioClipCollection;

        public BackgroundMusicPresenterFactory(
            AudioClipCollection audioClipCollection,
            IVolumeService volumeService,
            IPauseService pauseService)
        {
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
            _audioClipCollection = audioClipCollection 
                ? audioClipCollection 
                : throw new ArgumentNullException(nameof(audioClipCollection));
        }

        public BackgroundMusicPresenter Create(IBackgroundMusicView backgroundMusicView)
        {
            return new BackgroundMusicPresenter(
                _audioClipCollection, 
                backgroundMusicView,
                _volumeService,
                _pauseService);
        }
    }
}