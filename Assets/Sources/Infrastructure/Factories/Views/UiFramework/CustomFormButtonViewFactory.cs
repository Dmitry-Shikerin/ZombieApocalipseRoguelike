using System;
using Sources.Controllers;
using Sources.Controllers.Presenters.UiFramework.Buttons;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.UiFramework;
using Sources.Presentation.Ui.Buttons;

namespace Sources.Infrastructure.Factories
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