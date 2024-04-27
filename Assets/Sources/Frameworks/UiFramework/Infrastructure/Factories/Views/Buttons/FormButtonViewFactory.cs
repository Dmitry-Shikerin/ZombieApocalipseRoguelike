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
        private readonly UiFormButtonClickService _uiFormButtonClickService;

        public FormButtonViewFactory(
            FormService formService,
            ButtonServiceCollection buttonServiceCollection,
            UiFormButtonClickService uiFormButtonClickService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _buttonServiceCollection = buttonServiceCollection ?? throw new ArgumentNullException(nameof(buttonServiceCollection));
            _uiFormButtonClickService = uiFormButtonClickService ?? throw new ArgumentNullException(nameof(uiFormButtonClickService));
        }

        public UiFormButton Create(UiFormButton view)
        {
            UiFormButtonPresenter presenter = new UiFormButtonPresenter(
                view, _formService, _buttonServiceCollection, _uiFormButtonClickService);
            
            view.Construct(presenter);

            return view;
        }
    }
}