using Sources.Controllers.Common;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;

namespace Sources.Frameworks.UiFramework.Controllers.Forms
{
    public class UiContainerPresenter : PresenterBase
    {
        private readonly IUiContainerService _uiContainerService;

        public UiContainerPresenter(
            UiContainer uiContainer,
            UiContainerServicesCollection uiContainerServicesCollection,
            UiContainerCustomServiceCollection uiContainerCustomServiceCollection)
        {
            if (uiContainer.FormId != FormId.Default)
                _uiContainerService = uiContainerServicesCollection.Get(uiContainer.FormId);
            if(uiContainer.CustomFormId != CustomFormId.Default)
                _uiContainerService = uiContainerCustomServiceCollection.Get(uiContainer.CustomFormId);
                
        }

        public override void Enable() =>
            _uiContainerService.Enable();

        public override void Disable() =>
            _uiContainerService.Disable();
    }
}