using System;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms
{
    public class UiContainerFactory
    {
        private readonly FormServicesCollection _formServicesCollection;

        public UiContainerFactory(FormServicesCollection formServicesCollection)
        {
            _formServicesCollection = formServicesCollection ?? 
                                      throw new ArgumentNullException(nameof(formServicesCollection));
        }

        public UiContainer Create(UiContainer container)
        {
            UiContainerPresenter presenter = new UiContainerPresenter(container, _formServicesCollection);
            
            container.Construct(presenter);   
            
            return container;
        }
    }
}