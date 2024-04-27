using System;
using Sources.Frameworks.UiFramework.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Services.Forms;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons
{
    public class FormButtonViewFactory
    {
        private readonly FormService _formService;
        private readonly ButtonServiceCollection _buttonServiceCollection;

        public FormButtonViewFactory(
            FormService formService,
            ButtonServiceCollection buttonServiceCollection)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _buttonServiceCollection = buttonServiceCollection ?? throw new ArgumentNullException(nameof(buttonServiceCollection));
        }

        public UiFormButton Create(UiFormButton view)
        {
            FormButtonPresenter presenter = new FormButtonPresenter(
                view, _formService, _buttonServiceCollection);
            
            view.Construct(presenter);

            return view;
        }
    }
}