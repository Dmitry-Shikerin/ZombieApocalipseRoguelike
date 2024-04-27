using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Services.Forms
{
    public class FormService : IFormService
    {
        private readonly ContainerView _containerView;
        private readonly Dictionary<FormId, IUiContainer> _forms = new Dictionary<FormId, IUiContainer>();
        
        private readonly Dictionary<ButtonId, Action> _buttonActions = new Dictionary<ButtonId, Action>();
        private readonly Dictionary<ButtonId, Action<UiFormButton>> _enabledButtonActions =
            new Dictionary<ButtonId, Action<UiFormButton>>();
        private readonly Dictionary<ButtonId, Action<UiFormButton>> _disabledButtonActions =
            new Dictionary<ButtonId, Action<UiFormButton>>();
        
        private readonly Dictionary<FormId, Action<UiFormButton>> _formEnabledActions = 
            new Dictionary<FormId, Action<UiFormButton>>();
        private readonly Dictionary<FormId, Action<UiFormButton>> _formDisabledActions = 
            new Dictionary<FormId, Action<UiFormButton>>();

        public FormService(GameplayHud gameplayHud)
        {
            foreach (IUiContainer form in gameplayHud.UiCollector.UiContainers)
                _forms.Add(form.Id, form);
        }

        public FormService AddButtonAction(ButtonId buttonId, Action onClick)
        {
            if (_buttonActions.ContainsKey(buttonId))
                throw new InvalidOperationException(nameof(buttonId));

            _buttonActions[buttonId] = onClick;

            return this;
        }

        public FormService AddFormButtonEnabledAction(FormId formId, Action<UiFormButton> onClick)
        {
            if (_formEnabledActions.ContainsKey(formId))
                throw new InvalidOperationException(nameof(formId));

            _formEnabledActions[formId] = onClick;

            return this;
        }
        
        public FormService AddFormButtonDisabledAction(FormId formId, Action<UiFormButton> onClick)
        {
            if (_formDisabledActions.ContainsKey(formId))
                throw new InvalidOperationException(nameof(formId));

            _formDisabledActions[formId] = onClick;

            return this;
        }
        
        public Action<UiFormButton> GetFormButtonEnabledAction(FormId formId)
        {
            if (_formEnabledActions.ContainsKey(formId) == false)
                return ((view) => { });
            
            return _formEnabledActions[formId];
        }
        
        public Action<UiFormButton> GetFormButtonDisabledAction(FormId formId)
        {
            Debug.Log("GetFormButtonDisabledAction: " + formId);
            if (_formDisabledActions.ContainsKey(formId) == false)
                return ((view) => { });
            
            return _formDisabledActions[formId];
        }

        public FormService AddEnabledButtonAction(ButtonId buttonId, Action<UiFormButton> enabledAction)
        {
            if (_enabledButtonActions.ContainsKey(buttonId))
                throw new InvalidOperationException(nameof(buttonId));

            _enabledButtonActions[buttonId] = enabledAction;

            return this;
        }

        public FormService AddDisabledButtonAction(ButtonId buttonId, Action<UiFormButton> disabledAction)
        {
            if (_disabledButtonActions.ContainsKey(buttonId))
                throw new InvalidOperationException(nameof(buttonId));
            
            _disabledButtonActions[buttonId] = disabledAction;

            return this;
        }

        //TODO чепуха ли?
        public Action<UiFormButton> GetEnabledButtonAction(ButtonId buttonId)
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
            // string name = typeof(T).Name;
            //
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

            _forms.Add(uiContainer.Id, uiContainer);
            uiContainer.Hide();
        }
    }
}