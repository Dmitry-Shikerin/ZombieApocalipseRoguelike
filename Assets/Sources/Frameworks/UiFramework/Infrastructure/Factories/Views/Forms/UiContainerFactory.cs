using System;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms
{
    public class UiContainerFactory
    {
        private readonly UiContainerServicesCollection _uiContainerServicesCollection;

        public UiContainerFactory(UiContainerServicesCollection uiContainerServicesCollection)
        {
            _uiContainerServicesCollection = uiContainerServicesCollection ?? 
                                      throw new ArgumentNullException(nameof(uiContainerServicesCollection));
        }

        public UiContainer Create(UiContainer container)
        {
            UiContainerPresenter presenter = new UiContainerPresenter(container, _uiContainerServicesCollection);
            
            container.Construct(presenter);   
            
            return container;
        }
    }
}