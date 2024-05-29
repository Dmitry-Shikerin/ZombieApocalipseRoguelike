using Sources.Frameworks.UiFramework.Presentation.Views.Types;

namespace Sources.Frameworks.UiFramework.ServicesInterfaces.Forms
{
    public interface IFormService
    {
        void Show(FormId formId);

        void Hide(FormId formId);

        void ShowAll();

        void HideAll();

        bool IsActive(FormId formId);
    }
}
