using System;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Presentations.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Frameworks.UiFramework.Presentation.AudioSources
{
    [RequireComponent(typeof(AudioSource))]
    public class UiAudioSource : View
    {
        [DisplayAsString(false)] [HideLabel]
        [SerializeField] private string _lebel = UiConstant.UiAudioSourceLabel;
        
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            if (_audioSource.clip == null)
                Debug.Log($"Missing audio clip in {nameof(UiAudioSource)}");
        }
    }
}