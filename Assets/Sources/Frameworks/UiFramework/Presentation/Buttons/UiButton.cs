﻿using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Presentation.Views.Types;
using Sources.Frameworks.UiFramework.PresentationsInterfaces.Buttons;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Buttons
{
    public class UiButton : PresentableUiButton<UiButtonPresenter>, IUiButton
    {
        [DisplayAsString(false)] [HideLabel] [Indent(8)] [SerializeField]
        private string _labelText = UiConstant.UiButtonLabel;

        [TabGroup("Ids")] [SerializeField]
        private FormId _formId;
        
        [TabGroup("Settings")] [SerializeField]
        private UseButtonType _useButtonType;

        [TabGroup("Settings")] [Range(0f, 1000f)] [SerializeField]
        private float _delay;

        [TabGroup("Commands")] [SerializeField]
        private List<ButtonCommandId> _onClickCommandId;

        [TabGroup("Commands")] [SerializeField]
        private List<ButtonCommandId> enableCommandId;

        [TabGroup("Commands")] [SerializeField]
        private List<ButtonCommandId> _disableCommandId;

        public float Delay => _delay;
        public List<ButtonCommandId> OnClickCommandId => _onClickCommandId;
        public List<ButtonCommandId> EnableCommandId => enableCommandId;
        public List<ButtonCommandId> DisableCommandId => _disableCommandId;
        public UseButtonType UseButtonType => _useButtonType;
        public FormId FormId => _formId;
    }
}