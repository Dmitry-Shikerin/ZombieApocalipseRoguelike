using System;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Infrastructure.Services.Forms;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms
{
    public class UiContainerFactory
    {
        private readonly UiViewService _uiViewService;
        private readonly IFormService _formService;

        public UiContainerFactory(UiViewService uiViewService, IFormService formService)
        {
            _uiViewService = uiViewService ?? throw new ArgumentNullException(nameof(uiViewService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public UiView Create(UiView view)
        {
            UiViewPresenter presenter = new UiViewPresenter(
                view,
                _uiViewService,
                _formService);
            
            view.Construct(presenter);   
            
            return view;
        }
    }
}