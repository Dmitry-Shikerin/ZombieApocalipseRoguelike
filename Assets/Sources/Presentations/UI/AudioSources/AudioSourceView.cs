using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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

        public void Mute() =>
            _audioSource.mute = true;

        public void UnMute() =>
            _audioSource.mute = false;

        public void Pause() =>
            _audioSource.Pause();

        public void UnPause() =>
            _audioSource.UnPause();

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

        public async UniTask PlayToEnd(CancellationToken cancellationToken)
        {
            // _audioSource.clip.LoadAudioData();
            //
            Play();
            await UniTask.WaitUntil(
                () => Mathf.Approximately(_audioSource.time, _audioSource.clip.length),
                cancellationToken: cancellationToken);
        }

        // private void Update()
        // {
        //     if(_audioSource.clip == null)
        //         return;
        //     
        //     Debug.Log($"Audio source time: {_audioSource.time}");
        //     Debug.Log($"Audio source length: {_audioSource.clip.length}");
        // }
    }
}