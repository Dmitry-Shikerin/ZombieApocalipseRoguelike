using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.UI.AudioSources;
using UnityEngine;

namespace Sources.Presentations.UI.AudioSources
{
    public class AudioSourceView : View, IAudioSourceView
    {
        [Required] [SerializeField] private AudioSource _audioSource;

        public bool IsPlaying => _audioSource.isPlaying;

        public void Play() =>
            _audioSource.Play();

        public void SetLoop() =>
            _audioSource.loop = true;

        public void SetUnLoop() =>
            _audioSource.loop = false;

        public void Stop() =>
            _audioSource.Stop();

        public void SetClip(AudioClip audioClip) =>
            _audioSource.clip = audioClip;

        public void SetVolume(float volume) =>
            _audioSource.volume = volume;

        public void Set()
        {
        }
    }
}