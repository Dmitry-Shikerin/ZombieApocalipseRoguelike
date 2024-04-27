using Sources.Presentation.Views.Forms.Types;

namespace Sources.PresentationsInterfaces.Views.Forms.Common
{
    public interface IFormView : IView
    {
        FormId Id { get; }
    }
}
