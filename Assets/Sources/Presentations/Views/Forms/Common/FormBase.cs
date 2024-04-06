using Sources.ControllersInterfaces;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Presentations.Views.Forms.Common
{
    public class FormBase<T> : PresentableView<T>, IFormView
        where T : IPresenter
    {
    }
}