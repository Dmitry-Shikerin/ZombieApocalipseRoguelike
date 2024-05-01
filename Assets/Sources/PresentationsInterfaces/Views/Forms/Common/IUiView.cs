using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;

namespace Sources.PresentationsInterfaces.Views.Forms.Common
{
    public interface IUiView : IView
    {
        public Enable EnabledGameObject { get; }
        public Enable EnabledCanvasGroup { get; }
        public ContainerType ContainerType { get; }
        public IReadOnlyList<FormId> OnEnableEnabledForms { get; }
        public IReadOnlyList<FormId> OnEnableDisabledForms { get; }
        
        FormId FormId { get; }
        CustomFormId CustomFormId { get; }
    }
}
