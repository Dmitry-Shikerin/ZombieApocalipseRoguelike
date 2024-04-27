using Sirenix.OdinInspector;
using Sources.MVVMFrameworks.Domain.Methods;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sources.Frameworks.MVVM.Binds.Buttons
{
    public class ButtonClickMethodBind : BindableViewMethod<Vector3>, IButtonClickMethodBind
    {
        [Required] [SerializeField] private Button _button;

        private void OnEnable()
        {
            AddListener(OnButtonClick);
            OnAfterEnable();
        }

        private void OnDisable()
        {
            RemoveListener(OnButtonClick);
            OnAfterDisable();
        }

        protected virtual void OnAfterEnable()
        {
        }

        protected virtual void OnAfterDisable()
        {
        }

        protected void AddListener(UnityAction action) =>
            _button.onClick.AddListener(action);
        
        protected void RemoveListener(UnityAction action) =>
            _button.onClick.RemoveListener(action);

        private void OnButtonClick() =>
            BindingCallback.Invoke(Input.mousePosition);
    }
}