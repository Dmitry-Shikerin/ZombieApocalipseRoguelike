using System;
using Sources.Controllers.Musics;
using Sources.Domain.AudioSources;
using Sources.Presentations.Views.Music;

namespace Sources.Infrastructure.Factories.Controllers.Musics
{
    public class BackgroundMusicPresenterFactory
    {
        private readonly AudioClipCollection _audioClipCollection;

        public BackgroundMusicPresenterFactory(AudioClipCollection audioClipCollection)
        {
            _audioClipCollection = audioClipCollection 
                ? audioClipCollection 
                : throw new ArgumentNullException(nameof(audioClipCollection));
        }

        public BackgroundMusicPresenter Create(IBackgroundMusicView backgroundMusicView)
        {
            return new BackgroundMusicPresenter(_audioClipCollection, backgroundMusicView);
        }
    }
}