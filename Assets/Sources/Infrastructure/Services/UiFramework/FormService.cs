using System;
using System.Collections.Generic;
using System.Linq;
using Sources.InfrastructureInterfaces.Services;
using Sources.Presentation;
using Sources.Presentation.Ui.Buttons;
using Sources.Presentation.Ui.Buttons.Types;
using Sources.Presentation.Views.Forms;
using Sources.Presentation.Views.Forms.Types;
using Sources.Presentations.UiFramework.Buttons.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Infrastructure.Services
{
    public class FormService : IFormService
    {
        private readonly ContainerView _containerView;
        private readonly Dictionary<FormId, IFormView> _forms = new Dictionary<FormId, IFormView>();
        private readonly Dictionary<ButtonId, Action> _buttonActions = new Dictionary<ButtonId, Action>();

        private readonly Dictionary<ButtonId, Action<FormButtonView>> _enabledButtonActions =
            new Dictionary<ButtonId, Action<FormButtonView>>();

        public FormService(UiCollector uiCollector)
        {
            foreach (FormView form in uiCollector.Forms)
                _forms.Add(form.Id, form);
        }

        public FormService AddButtonAction(ButtonId buttonId, Action onClick)
        {
            if (_buttonActions.ContainsKey(buttonId))
                throw new InvalidOperationException(nameof(buttonId));

            _buttonActions[buttonId] = onClick;

            return this;
        }

        public FormService AddEnabledButtonAction(ButtonId buttonId, Action<FormButtonView> enabledAction)
        {
            if (_enabledButtonActions.ContainsKey(buttonId))
                throw new InvalidOperationException(nameof(buttonId));

            _enabledButtonActions[buttonId] = enabledAction;

            return this;
        }

        //TODO чепуха ли?
        public Action<FormButtonView> GetEnabledButtonAction(ButtonId buttonId)
        {
            if (_enabledButtonActions.ContainsKey(buttonId) == false)
                return ((view) => { });
            
            return _enabledButtonActions[buttonId] ;
        }

        public Action GetButtonAction(ButtonId buttonId)
        {
            if (_buttonActions.ContainsKey(buttonId) == false)
                throw new NullReferenceException(nameof(buttonId));

            return _buttonActions[buttonId];
        }

        public void Show(FormId formId)
        {
            if (_forms.ContainsKey(formId) == false)
            {
                throw new NullReferenceException(nameof(formId));
            }

            IFormView activeForm = _forms[formId];

            _forms.Values
                .Except(new List<IFormView> { activeForm, })
                .ToList()
                .ForEach(form => form.Hide());

            activeForm.Show();
        }

        public void Hide(FormId formId)
        {
            // string name = typeof(T).Name;
            //
            if (_forms.ContainsKey(formId) == false)
                throw new NullReferenceException(nameof(formId));

            IFormView activeForm = _forms[formId];

            if (activeForm == null)
                throw new NullReferenceException(nameof(activeForm));

            activeForm.Hide();
        }

        public void Add(IFormView formView, string name = null, bool isSetParent = false)
        {
            if (isSetParent)
                _containerView.AppendChild(formView);

            _forms.Add(formView.Id, formView);
            formView.Hide();
        }
    }
}