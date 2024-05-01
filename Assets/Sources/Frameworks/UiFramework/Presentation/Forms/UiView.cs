using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    public class UiView : PresentableView<UiContainerPresenter>, IUiView
    {
        [DisplayAsString(false)] [HideLabel] [Indent(8)]
        [SerializeField] private string _label = UiConstant.UiContainerLabel;
        
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
        
        [TabGroup("Enabled Settings")]
        [SerializeField] private List<FormId> _enabledForms = new List<FormId>();
        
        [TabGroup("Enabled Settings")]
        [SerializeField] private List<FormId> _disabledForms = new List<FormId>();
        
        [Space(10)]
        [TabGroup("Enabled Settings")]
        [SerializeField] private List<FormCommandId> _enabledFormCommads = new List<FormCommandId>();
        
        [TabGroup("Enabled Settings")]
        [SerializeField] private List<FormCommandId> _disabledFormCommands = new List<FormCommandId>();
        
        public string Label => _label;
        public Enable EnabledGameObject => _enabledGameObject;
        public Enable EnabledCanvasGroup => _EnabledCanvasGroup;
        public ContainerType ContainerType => _containerType;
        public List<FormId> EnabledForms => _enabledForms;
        public List<FormId> DisabledForms => _disabledForms;
        
        public FormId FormId => _formId;
        public CustomFormId CustomFormId => _customFormId;
    }
}