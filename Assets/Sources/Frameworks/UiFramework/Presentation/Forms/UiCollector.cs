using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    [DefaultExecutionOrder(-1)]
    public class UiCollector : View
    {
        //[Button(ButtonSizes.Large)] 
        //[FoldoutGroup("UiContainers")] [Required] [SerializeField]
        //private List<UiContainer> _uiContainers;
        //
        //[Button(ButtonSizes.Large)] 
        //[FoldoutGroup("UiButtons")] [Required] [SerializeField]
        //private List<UiFormButton> _uiFormButtons;

        private List<UiFormButton> _uiFormButtons;
        private List<UiContainer> _uiContainers;

        public IReadOnlyList<UiFormButton> UiFormButtons => _uiFormButtons;
        public IReadOnlyList<IUiContainer> UiContainers => _uiContainers;

        private void Awake()
        {
            _uiFormButtons = GetComponentsInChildren<UiFormButton>(true).ToList();
            _uiContainers = GetComponentsInChildren<UiContainer>(true).ToList();
        }
    }
}