using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Presentation.Ui.Buttons;
using Sources.Presentations.UiFramework.Forms;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Cameras;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Presentation.Views.Forms
{
    [DefaultExecutionOrder(-1)]
    public class UiCollector : View
    {
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("UiContainers")] [Required] [SerializeField]
        private List<UiContainer> _uiContainers;
        
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("UiButtons")] [Required] [SerializeField]
        private List<UiFormButton> _uiFormButtons;

        public IReadOnlyList<UiFormButton> UiFormButtons => _uiFormButtons;
        public IReadOnlyList<IUiContainer> UiContainers => _uiContainers;
    }
}