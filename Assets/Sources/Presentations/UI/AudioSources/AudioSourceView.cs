using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.UI.AudioSources;
using UnityEngine;

namespace Sources.Presentations.UI.AudioSources
{
    public class AudioSourceView : View, IAudioSourceView
    {
        [Required] [SerializeField] private AudioSource _audioSource;

        public void Play() =>
            _audioSource.Play();

        public void SetLoop() =>
            _audioSource.loop = true;

        public void Stop() =>
            _audioSource.Stop();
    }
}