using System;
using Sources.Frameworks.UiFramework.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Controllers.Buttons
{
    public class UiButtonPresenterFactory
    {
        private readonly IUiButtonService _uiButtonService;

        public UiButtonPresenterFactory(IUiButtonService uiButtonService)
        {
            _uiButtonService = uiButtonService ?? 
                                   throw new ArgumentNullException(nameof(uiButtonService));
        }

        public UiButtonPresenter Create(UiButton view) =>
            new(view, _uiButtonService);
    }
}