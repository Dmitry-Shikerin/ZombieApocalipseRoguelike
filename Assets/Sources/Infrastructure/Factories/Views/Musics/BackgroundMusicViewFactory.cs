using System;
using Sources.Controllers.Musics;
using Sources.Infrastructure.Factories.Controllers.Musics;
using Sources.Presentations.Views.Music;

namespace Sources.Infrastructure.Factories.Views.Musics
{
    public class BackgroundMusicViewFactory
    {
        private readonly BackgroundMusicPresenterFactory _backgroundMusicPresenterFactory;

        public BackgroundMusicViewFactory(BackgroundMusicPresenterFactory backgroundMusicPresenterFactory)
        {
            _backgroundMusicPresenterFactory = 
                backgroundMusicPresenterFactory 
                ?? throw new ArgumentNullException(nameof(backgroundMusicPresenterFactory));
        }

        public IBackgroundMusicView Create(BackgroundMusicView backgroundMusicView)
        {
            BackgroundMusicPresenter backgroundMusicPresenter = 
                _backgroundMusicPresenterFactory.Create(backgroundMusicView);
            backgroundMusicView.Construct(backgroundMusicPresenter);
            
            return backgroundMusicView;
        }
    }
}