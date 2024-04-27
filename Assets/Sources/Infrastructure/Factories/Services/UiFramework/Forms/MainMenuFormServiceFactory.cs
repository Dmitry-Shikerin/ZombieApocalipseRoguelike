using System;
using System.Collections;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms;
using Sources.Frameworks.UiFramework.Services.Forms;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Factories.Services.UiFramework.Forms
{
    public class MainMenuFormServiceFactory : FormServiceFactoryBase
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly FormService _formService;

        public MainMenuFormServiceFactory(
            MainMenuHud mainMenuHud,
            FormService formService,
            CustomFormButtonViewFactory customFormButtonViewFactory,
            FormButtonViewFactory formButtonViewFactory,
            UiContainerFactory uiContainerFactory) 
            : base(
                customFormButtonViewFactory, 
                formButtonViewFactory,
                uiContainerFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public IFormService Create()
        {
            CreateFormButtons(_mainMenuHud.UiCollector.UiFormButtons);            

            return _formService;
        }
    }
}