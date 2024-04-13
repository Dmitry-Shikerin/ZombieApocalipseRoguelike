using UnityEngine;

namespace Sources.PresentationsInterfaces.UI.AudioSources
{
    public interface IAudioSourceView
    {
        bool IsPlaying { get; }
        
        void Play();
        void SetLoop();
        void SetUnLoop();
        void Stop();
        void SetClip(AudioClip audioClip);
    }
}