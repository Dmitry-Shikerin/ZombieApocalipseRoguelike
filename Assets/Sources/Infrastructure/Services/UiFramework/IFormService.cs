using Sources.Presentations.UiFramework.Forms.Types;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.InfrastructureInterfaces.Services
{
    public interface IFormService
    {
        void Show(FormId formId);
        void Hide(FormId formId);
        void Add(IUiContainer uiContainer, string name = null, bool isSetParent = false);
    }
}
