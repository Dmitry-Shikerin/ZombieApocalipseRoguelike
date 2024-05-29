using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.UI.Buttons
{
    public class ButtonSoundView : ButtonView
    {
        [Required][SerializeField] private AudioSource _audioSource;

        private void Awake() =>
            _audioSource.loop = false;

        private void OnEnable() =>
            AddClickListener(OnClick);

        private void OnDisable() =>
            RemoveClickListener(OnClick);

        private void OnClick() =>
            _audioSource.Play();
    }
}