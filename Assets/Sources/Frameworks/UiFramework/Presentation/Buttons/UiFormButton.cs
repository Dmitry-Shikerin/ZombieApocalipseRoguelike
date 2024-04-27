using Sources.Frameworks.UiFramework.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Buttons
{
    public class UiFormButton : PresentableFormButton<FormButtonPresenterBase>
    {
        [SerializeField] private FormId _formId;
        [SerializeField] private ButtonType _buttonType;
        [SerializeField] private ButtonId _buttonId;
        [SerializeField] private UseButtonType _useButtonType;
        [SerializeField] private float _delay;
        
        public float Delay => _delay;
        public UseButtonType UseButtonType => _useButtonType;
        public ButtonId ButtonId => _buttonId;
        public ButtonType ButtonType => _buttonType;
        public FormId FormId => _formId;
    }
}