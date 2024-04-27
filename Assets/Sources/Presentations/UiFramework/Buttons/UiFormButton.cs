using Sources.Controllers;
using Sources.Controllers.Common.UiFramework.Buttons;
using Sources.Presentation.Ui.Buttons.Types;
using Sources.Presentations.UiFramework.Buttons.Types;
using Sources.Presentations.UiFramework.Forms.Types;
using UnityEngine;

namespace Sources.Presentation.Ui.Buttons
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