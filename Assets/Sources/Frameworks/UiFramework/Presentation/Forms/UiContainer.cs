using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    public class UiContainer : PresentableView<UiContainerPresenter>, IUiContainer
    {
        [DisplayAsString(false)] [HideLabel] [Indent(8)]
        [SerializeField] private string _lebel = UiConstant.UiContainerLabel;
        
        [TabGroup("Showed Settings")]
        [EnumToggleButtons] [HideLabel] [LabelText("Enabled GameObject")]
        [SerializeField] private Enable _enabledGameObject;
        
        [TabGroup("Showed Settings")]
        [EnumToggleButtons] [HideLabel] [LabelText("Enabled CanvasGroup")]
        [SerializeField] private Enable _EnabledCanvasGroup;
        
        [TabGroup("Type")] [EnumToggleButtons]
        [SerializeField] private ContainerType _containerType = ContainerType.Form;
        
        [TabGroup("Type")] [EnableIf(nameof(_customFormId), CustomFormId.Default)]
        [SerializeField] private FormId _formId;
        
        [TabGroup("Type")] [EnableIf(nameof(_formId), FormId.Default)]
        [SerializeField] private CustomFormId _customFormId = CustomFormId.Default;
        
        public FormId FormId => _formId;
        public CustomFormId CustomFormId => _customFormId;
    }
}