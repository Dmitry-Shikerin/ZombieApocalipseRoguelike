using Sources.ControllersInterfaces.Presenters;
using Sources.Frameworks.UiFramework.Presentation.Views.Types;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Presentations.Views.Forms.Common
{
    public class FormBase<T> : PresentableView<T>, IFormView
        where T : IPresenter
    {
        public FormId FormId { get; }
        public CustomFormId CustomFormId { get; }
    }
}