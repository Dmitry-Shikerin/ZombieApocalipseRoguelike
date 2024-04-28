using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    public class UiContainer : PresentableView<UiContainerPresenter>, IUiContainer
    {
        [SerializeField] private FormId _formId;

        // [Title("Showed Settings")]
        [TabGroup("Showed Settings")]
        [EnumToggleButtons] [HideLabel]
        public Enable _enabled;

        [TabGroup("Id"), GUIColor(0.4f, 0.8f, 1)] 
        [SerializeField] private string _id;
        
        public FormId Id => _formId;
        public bool IsEnabled => _enabled == Enable.Enable;
    }
}