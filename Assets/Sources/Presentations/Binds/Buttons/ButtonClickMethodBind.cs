using Sirenix.OdinInspector;
using Sources.MVVMFrameworks.Domain.Methods;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Presentations.Binds.Buttons
{
    public class ButtonClickMethodBind : BindableViewMethod<Vector3>, IButtonClickMethodBind
    {
        [Required][SerializeField] private Button _button;

        private void OnEnable() => 
            _button?.onClick.AddListener(OnButtonClick);

        private void OnDisable() => 
            _button?.onClick.RemoveListener(OnButtonClick);

        //TODO нужно ли оставлять Canvas на корневом обьекте?
        private void OnButtonClick() => 
            BindingCallback.Invoke(Input.mousePosition);
    }
}