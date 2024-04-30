using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Frameworks.UiFramework.ServicesInterfaces.Forms
{
    public interface IFormService
    {
        void Show(FormId formId);
        void Hide(FormId formId);
        void ShowCustomContainer(CustomFormId formId);
        void HideCustomContainer(CustomFormId formId);
        void Add(IUiContainer uiContainer, string name = null, bool isSetParent = false);
    }
}
