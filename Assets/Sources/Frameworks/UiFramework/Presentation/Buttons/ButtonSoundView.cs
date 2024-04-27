using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Buttons
{
    public class ButtonSoundView : ButtonView
    {
        [TabGroup("Components")]
        [SerializeField] private AudioSource _audioSource;

        private void Awake() =>
            _audioSource.loop = false;

        protected void OnEnable()
        {
            AddClickListener(OnClick);
            OnAfterEnable();
        }

        protected void OnDisable()
        {
            RemoveClickListener(OnClick);
            OnAfterDisable();
        }

        protected virtual void OnAfterEnable()
        {
        }

        protected virtual void OnAfterDisable()
        {
        }

        private void OnClick() =>
            _audioSource.Play();
    }
}