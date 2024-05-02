using System;
using Sources.Frameworks.UiFramework.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Services.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons
{
    public class FormButtonViewFactory
    {
        private readonly UiButtonViewService _uiButtonViewService;

        public FormButtonViewFactory(
            UiButtonViewService uiButtonViewService)
        {
            _uiButtonViewService = uiButtonViewService ?? throw new ArgumentNullException(nameof(uiButtonViewService));
        }

        public UiUiUiUiButton Create(UiUiUiUiButton view)
        {
            UiFormButtonPresenter presenter = new UiFormButtonPresenter(
                view, _uiButtonViewService);
            
            view.Construct(presenter);

            return view;
        }
    }
}