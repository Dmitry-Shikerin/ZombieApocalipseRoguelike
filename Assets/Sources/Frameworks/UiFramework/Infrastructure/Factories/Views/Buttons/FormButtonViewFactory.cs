using System;
using Sources.Frameworks.UiFramework.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons
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