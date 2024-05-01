using System;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms
{
    public class UiContainerFactory
    {
        private readonly UiContainerServicesCollection _uiContainerServicesCollection;
        private readonly UiContainerCustomServiceCollection _uiContainerCustomServiceCollection;

        public UiContainerFactory(
            UiContainerServicesCollection uiContainerServicesCollection,
            UiContainerCustomServiceCollection uiContainerCustomServiceCollection)
        {
            _uiContainerServicesCollection = uiContainerServicesCollection ?? 
                                             throw new ArgumentNullException(nameof(uiContainerServicesCollection));
            _uiContainerCustomServiceCollection = 
                uiContainerCustomServiceCollection ?? 
                throw new ArgumentNullException(nameof(uiContainerCustomServiceCollection));
        }

        public UiView Create(UiView view)
        {
            UiContainerPresenter presenter = new UiContainerPresenter(
                view, 
                _uiContainerServicesCollection,
                _uiContainerCustomServiceCollection);
            
            view.Construct(presenter);   
            
            return view;
        }
    }
}