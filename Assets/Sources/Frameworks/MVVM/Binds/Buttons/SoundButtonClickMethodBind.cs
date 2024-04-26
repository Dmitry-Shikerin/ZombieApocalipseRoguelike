using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.Binds.Buttons
{
    public class SoundButtonClickMethodBind : ButtonClickMethodBind
    {
        [Required] [SerializeField] private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource.loop = false;
            _audioSource.playOnAwake = false;
        }

        protected override void OnAfterEnable() =>
            AddListener(Play);

        protected override void OnAfterDisable() =>
            RemoveListener(Play);

        private void Play() =>
            _audioSource.Play();
    }
}