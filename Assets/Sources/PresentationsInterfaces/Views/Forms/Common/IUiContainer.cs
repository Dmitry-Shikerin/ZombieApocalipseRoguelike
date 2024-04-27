using Sources.Frameworks.UiFramework.Presentation.Forms.Types;

namespace Sources.PresentationsInterfaces.Views.Forms.Common
{
    public interface IUiContainer : IView
    {
        FormId Id { get; }
    }
}
