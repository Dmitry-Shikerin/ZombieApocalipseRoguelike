using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Sources.PresentationsInterfaces.UI.AudioSources
{
    public interface IAudioSourceView
    {
        bool IsPlaying { get; }

        void Mute();
        void UnMute();
        void Pause();
        void UnPause();
        void Play();
        UniTask PlayToEnd(CancellationToken cancellationToken);
        void SetLoop();
        void SetUnLoop();
        void Stop();
        void SetClip(AudioClip audioClip);
        void SetVolume(float volume);
    }
}