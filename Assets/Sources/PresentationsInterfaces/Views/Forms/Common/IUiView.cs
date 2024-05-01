using Sources.Frameworks.UiFramework.Presentation.Forms.Types;

namespace Sources.PresentationsInterfaces.Views.Forms.Common
{
    public interface IUiView : IView
    {
        FormId FormId { get; }
        CustomFormId CustomFormId { get; }
    }
}
