using System;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Controllers.Buttons
{
    public class FormButtonPresenter : FormButtonPresenterBase
    {
        private readonly IFormService _formService;
        private readonly UiFormButton _view;

        public FormButtonPresenter(UiFormButton view, IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public override void Enable() =>
            _view.AddClickListener(ShowForm);

        public override void Disable() =>
            _view.RemoveClickListener(ShowForm);

        private void ShowForm() =>
            _formService.Show(_view.FormId);
    }
}