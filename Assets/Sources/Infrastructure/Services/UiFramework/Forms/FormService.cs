using System;
using System.Collections.Generic;
using System.Linq;
using Sources.InfrastructureInterfaces.Services;
using Sources.Presentation.Ui.Buttons;
using Sources.Presentation.Views.Forms;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.UiFramework.Buttons.Types;
using Sources.Presentations.UiFramework.Forms.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Infrastructure.Services.UiFramework
{
    public class FormService : IFormService
    {
        private readonly ContainerView _containerView;
        private readonly Dictionary<FormId, IUiContainer> _forms = new Dictionary<FormId, IUiContainer>();
        private readonly Dictionary<ButtonId, Action> _buttonActions = new Dictionary<ButtonId, Action>();

        private readonly Dictionary<ButtonId, Action<UiFormButton>> _enabledButtonActions =
            new Dictionary<ButtonId, Action<UiFormButton>>();

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

        public FormService AddEnabledButtonAction(ButtonId buttonId, Action<UiFormButton> enabledAction)
        {
            if (_enabledButtonActions.ContainsKey(buttonId))
                throw new InvalidOperationException(nameof(buttonId));

            _enabledButtonActions[buttonId] = enabledAction;

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
            {
                throw new NullReferenceException(nameof(formId));
            }

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