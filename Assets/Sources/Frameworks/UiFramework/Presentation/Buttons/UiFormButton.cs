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
        [SerializeField] private FormId _formId;
        [TabGroup("Ids")]
        [SerializeField] private ButtonId _buttonId;
        [TabGroup("Settings")]
        [SerializeField] private ButtonType _buttonType;
        [TabGroup("Settings")]
        [SerializeField] private UseButtonType _useButtonType;
        [TabGroup("Settings")]
        [SerializeField] private float _delay;
        
        public float Delay => _delay;
        public UseButtonType UseButtonType => _useButtonType;
        public ButtonId ButtonId => _buttonId;
        public ButtonType ButtonType => _buttonType;
        public FormId FormId => _formId;
    }
}