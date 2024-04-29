using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore.Text;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    public class UiContainer : PresentableView<UiContainerPresenter>, IUiContainer
    {
        [DisplayAsString(false)] [HideLabel]
        [SerializeField] private string _lebel = UiConstant.UiContainerLabel;
        [SerializeField] private FormId _formId;
        [TabGroup("Showed Settings")]
        [EnumToggleButtons] [HideLabel]
        public Enable _enabled;

        [TabGroup("Id")] 
        [SerializeField] private string _id;
        
        public FormId Id => _formId;
        public bool IsEnabled => _enabled == Enable.Enable;
    }
}