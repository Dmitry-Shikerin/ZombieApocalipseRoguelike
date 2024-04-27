using System;
using Sources.Controllers.Common.UiFramework.Buttons;
using Sources.InfrastructureInterfaces.Services;
using Sources.Presentation.Ui.Buttons;

namespace Sources.Controllers
{
    public class FormButtonPresenter : FormButtonPresenterBase
    {
        private readonly IFormService _formService;
        private readonly FormButtonView _view;

        public FormButtonPresenter(FormButtonView view, IFormService formService)
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