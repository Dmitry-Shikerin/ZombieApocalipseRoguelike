using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Buttons
{
    public class UiFormButton : PresentableFormButton<UiFormButtonPresenter>
    {
        [TabGroup("Ids")] 
        [EnableIf("_buttonId", ButtonId.Default)] 
        [SerializeField] private FormId _formId;
        [TabGroup("Ids")] 
        [EnableIf("_formId", FormId.Default)] 
        [SerializeField] private ButtonId _buttonId;
        [TabGroup("Settings")] 
        [EnableIf("_formId", FormId.Default)]
        [SerializeField] private ButtonType _buttonType;
        [TabGroup("Settings")] 
        [SerializeField] private UseButtonType _useButtonType;
        [TabGroup("Settings")] [Range(0f, 1000f)]
        [SerializeField] private float _delay;

        [TabGroup("Settings")] public float Delay => _delay;
        public UseButtonType UseButtonType => _useButtonType;
        public ButtonId ButtonId => _buttonId;
        public ButtonType ButtonType => _buttonType;
        public FormId FormId => _formId;
    }
}