using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Frameworks.UiFramework.ServicesInterfaces.Forms
{
    public interface IFormService
    {
        void ShowOneForm(FormId formId);
        void HideOneForm(FormId formId);
        void Show(FormId formId);
        void Hide(FormId formId);
        void Add(IUiView uiView, string name = null, bool isSetParent = false);
    }
}
