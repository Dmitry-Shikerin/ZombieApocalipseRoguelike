using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Frameworks.UiFramework.Services.Forms
{
    public class FormService : IFormService
    {
        private readonly ContainerView _containerView;
        private readonly Dictionary<FormId, IUiContainer> _forms = new Dictionary<FormId, IUiContainer>();
        private readonly Dictionary<CustomFormId, IUiContainer> _customForms = 
            new Dictionary<CustomFormId, IUiContainer>();

        public FormService(UiCollector uiCollector)
        {
            foreach (IUiContainer form in uiCollector.UiContainers)
            {
                if (form.FormId != FormId.Default)
                    _forms.Add(form.FormId, form);
                if(form.CustomFormId != CustomFormId.Default)
                    _customForms.Add(form.CustomFormId, form);
            }
        }

        public void ShowCustomContainer(CustomFormId formId)
        {
            if (_customForms.ContainsKey(formId) == false)
                throw new KeyNotFoundException(nameof(formId));
            
            _customForms[formId].Show();
        }

        public void HideCustomContainer(CustomFormId formId)
        {
            if (_customForms.ContainsKey(formId) == false)
                throw new KeyNotFoundException(nameof(formId));
            
            _customForms[formId].Hide();
        }

        public void Show(FormId formId)
        {
            if (_forms.ContainsKey(formId) == false)
                throw new NullReferenceException(nameof(formId));

            IUiContainer activeForm = _forms[formId];

            _forms.Values
                .Except(new List<IUiContainer> { activeForm, })
                .ToList()
                .ForEach(form => form.Hide());

            activeForm.Show();
        }

        public void Hide(FormId formId)
        {
            if (_forms.ContainsKey(formId) == false)
                throw new NullReferenceException(nameof(formId));

            IUiContainer activeForm = _forms[formId];

            if (activeForm == null)
                throw new NullReferenceException(nameof(activeForm));

            activeForm.Hide();
        }

        public void Add(IUiContainer uiContainer, string name = null, bool isSetParent = false)
        {
            if (isSetParent)
                _containerView.AppendChild(uiContainer);

            _forms.Add(uiContainer.FormId, uiContainer);
            uiContainer.Hide();
        }
    }
}