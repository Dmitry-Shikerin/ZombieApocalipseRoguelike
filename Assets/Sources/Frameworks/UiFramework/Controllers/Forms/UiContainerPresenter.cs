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
            UiView uiView,
            UiContainerServicesCollection uiContainerServicesCollection,
            UiContainerCustomServiceCollection uiContainerCustomServiceCollection)
        {
            if (uiView.FormId != FormId.Default)
                _uiContainerService = uiContainerServicesCollection.Get(uiView.FormId);
            if(uiView.CustomFormId != CustomFormId.Default)
                _uiContainerService = uiContainerCustomServiceCollection.Get(uiView.CustomFormId);
                
        }

        public override void Enable() =>
            _uiContainerService.Enable();

        public override void Disable() =>
            _uiContainerService.Disable();
    }
}