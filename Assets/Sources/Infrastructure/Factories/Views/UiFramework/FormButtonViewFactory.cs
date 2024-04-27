using System;
using Sources.Controllers;
using Sources.Controllers.Presenters.UiFramework.Buttons;
using Sources.InfrastructureInterfaces.Services;
using Sources.Presentation.Ui.Buttons;

namespace Sources.Infrastructure.Factories
{
    public class FormButtonViewFactory
    {
        private readonly IFormService _formService;

        public FormButtonViewFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public UiFormButton Create(UiFormButton view)
        {
            FormButtonPresenter presenter = new FormButtonPresenter(view, _formService);
            
            view.Construct(presenter);

            return view;
        }
    }
}