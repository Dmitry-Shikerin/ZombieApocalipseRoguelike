﻿using System;
using Sources.Controllers.Common;
using Sources.Frameworks.UiFramework.Infrastructure.Services.Forms;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Controllers.Forms
{
    public class UiViewPresenter : PresenterBase
    {
        private readonly UiView _uiView;
        private readonly UiViewService _uiViewService;
        private readonly IFormService _formService;

        public UiViewPresenter(
            UiView uiView,
            UiViewService uiViewService,
            IFormService formService)
        {
            _uiView = uiView ? uiView : throw new ArgumentNullException(nameof(uiView));
            _uiViewService = uiViewService ?? throw new ArgumentNullException(nameof(uiViewService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _uiViewService.Handle(_uiView.EnabledFormCommands);

            foreach (FormId formId in _uiView.OnEnableEnabledForms)
                _formService.ShowOneForm(formId);
            foreach (FormId formId in _uiView.OnEnableDisabledForms)
                _formService.HideOneForm(formId);
        }

        public override void Disable()
        {
            _uiViewService.Handle(_uiView.DisabledFormCommands);
            
            foreach (FormId formId in _uiView.OnDisableEnabledForms)
                _formService.ShowOneForm(formId);
            foreach (FormId formId in _uiView.OnDisableDisabledForms)
                _formService.HideOneForm(formId);
        }
    }
}