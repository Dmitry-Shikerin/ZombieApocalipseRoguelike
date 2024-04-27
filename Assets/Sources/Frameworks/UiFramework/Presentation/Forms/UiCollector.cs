using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.Domain.Models.Localizations;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    public class UiCollector : View
    {
        [SerializeField] private Localization _localization;
        
        private List<UiFormButton> _uiFormButtons;
        private List<UiContainer> _uiContainers;
        private List<TextView> _textViews;

        public Localization Localization => _localization;
        public IReadOnlyList<UiFormButton> UiFormButtons => _uiFormButtons;
        public IReadOnlyList<UiContainer> UiContainers => _uiContainers;
        public IReadOnlyList<ITextView> TextViews => _textViews;

        private void Awake()
        {
            _uiFormButtons = GetComponentsInChildren<UiFormButton>(true).ToList();
            _uiContainers = GetComponentsInChildren<UiContainer>(true).ToList();
            _textViews = GetComponentsInChildren<TextView>(true).ToList();
        }
    }
}