using System;
using Sources.Controllers.Common;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Forms;

namespace Sources.Frameworks.UiFramework.Controllers.Forms
{
    public class UiContainerPresenter : PresenterBase
    {
        private readonly IUiContainerService _uiContainerService;

        public UiContainerPresenter(
            UiContainer uiContainer, 
            UiContainerServicesCollection uiContainerServicesCollection)
        {
            _uiContainerService = uiContainerServicesCollection.Get(uiContainer.Id);
        }

        public override void Enable() =>
            _uiContainerService.Enable();

        public override void Disable() =>
            _uiContainerService.Disable();
    }
}