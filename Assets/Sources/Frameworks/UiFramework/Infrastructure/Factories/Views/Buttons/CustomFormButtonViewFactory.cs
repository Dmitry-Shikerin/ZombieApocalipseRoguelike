using System;
using Sources.Frameworks.UiFramework.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Services.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons
{
    public class CustomFormButtonViewFactory
    {
        private readonly FormService _formService;

        public CustomFormButtonViewFactory(FormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public UiFormButton Create(UiFormButton view)
        {
            CustomFormButtonPresenter presenter = new CustomFormButtonPresenter(view, _formService);
            
            view.Construct(presenter);
            
            return view;
        }
    }
}