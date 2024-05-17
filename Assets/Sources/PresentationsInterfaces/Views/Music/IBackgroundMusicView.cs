using Sources.PresentationsInterfaces.UI.AudioSources;

namespace Sources.PresentationsInterfaces.Views.Music
{
    public interface IBackgroundMusicView
    {
        IAudioSourceView BackgroundMusicAudioSource { get; }
    }
}