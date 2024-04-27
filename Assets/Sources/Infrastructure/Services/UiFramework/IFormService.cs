using Sources.Presentation.Views.Forms.Types;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.InfrastructureInterfaces.Services
{
    public interface IFormService
    {
        void Show(FormId formId);
        void Hide(FormId formId);
        void Add(IFormView formView, string name = null, bool isSetParent = false);
    }
}
