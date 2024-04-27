using System;
using Sources.Controllers;
using Sources.Controllers.Common.UiFramework.Buttons;
using Sources.Infrastructure.Services;
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

        public FormButtonView Create(FormButtonView view)
        {
            CustomFormButtonPresenter presenter = new CustomFormButtonPresenter(view, _formService);
            
            view.Construct(presenter);
            
            return view;
        }
    }
}