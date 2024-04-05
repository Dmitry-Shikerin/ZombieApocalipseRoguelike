using Assets.Sources.PresentationsInterfaces.Views.Forms.Common;
using Sources.ControllersInterfaces;

namespace Sources.Presentations.Views.Forms.Common
{
    public class FormBase<T> : PresentableView<T>, IFormView
        where T : IPresenter
    {
    }
}