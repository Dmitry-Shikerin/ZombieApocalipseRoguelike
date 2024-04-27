using System;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Forms;

namespace Sources.Frameworks.UiFramework.Controllers.Forms
{
    public class UiContainerPresenter : UiContainerPresenterBase
    {
        private readonly IUiContainerService _uiContainerService;


        public UiContainerPresenter(UiContainer uiContainer, FormServicesCollection formServicesCollection)
        {
            _uiContainerService = formServicesCollection.Get(uiContainer.Id);
        }

        public override void Enable()
        {
            
        }

        public override void Disable()
        {
            base.Disable();
        }
    }
}