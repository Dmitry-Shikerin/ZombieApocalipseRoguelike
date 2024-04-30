using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers
{
    public class UiContainerCustomServiceCollection
    {
        private readonly Dictionary<CustomFormId, IUiContainerService> _formServices = 
            new Dictionary<CustomFormId, IUiContainerService>();
        
        public UiContainerCustomServiceCollection(
            UiContainerVoidService uiContainerVoidService)
        {
            _formServices[CustomFormId.Save] = uiContainerVoidService;
        }

        public IUiContainerService Get(CustomFormId uiContainerId) =>
            _formServices[uiContainerId];

    }
}