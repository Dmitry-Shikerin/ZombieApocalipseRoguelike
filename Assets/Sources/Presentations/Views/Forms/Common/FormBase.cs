using Sources.ControllersInterfaces;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Presentations.Views.Forms.Common
{
    public class FormBase<T> : PresentableView<T>, IUiView
        where T : IPresenter
    {
        public FormId FormId { get; }
        public CustomFormId CustomFormId { get; }
    }
}