using Sources.PresentationsInterfaces.UI.AudioSources;

namespace Sources.Presentations.Views.Music
{
    public interface IBackgroundMusicView
    {
        IAudioSourceView BackgroundMusicAudioSource { get; }
    }
}