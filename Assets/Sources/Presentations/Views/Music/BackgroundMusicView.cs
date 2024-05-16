using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Musics;
using Sources.Presentations.UI.AudioSources;
using Sources.PresentationsInterfaces.UI.AudioSources;
using Sources.PresentationsInterfaces.Views.Music;
using UnityEngine;

namespace Sources.Presentations.Views.Music
{
    public class BackgroundMusicView : PresentableView<BackgroundMusicPresenter>, IBackgroundMusicView
    {
        [Required] [SerializeField] private AudioSourceView _backgroundAudioSourceView;

        public IAudioSourceView BackgroundMusicAudioSource => _backgroundAudioSourceView;
    }
}