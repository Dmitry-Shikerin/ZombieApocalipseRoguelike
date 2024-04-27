using Sources.Presentation.Views.Forms.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Presentation.Views.Forms
{
    public class FormView : View, IFormView
    {
        [SerializeField] private FormId _formId;
        // [SerializeField] private List<FormButtonView> _buttons;
        
        public FormId Id => _formId;
        // public IReadOnlyList<FormButtonView> Buttons => _buttons;
    }
}