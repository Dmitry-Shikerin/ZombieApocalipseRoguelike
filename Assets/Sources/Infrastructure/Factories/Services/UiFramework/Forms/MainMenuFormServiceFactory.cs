using System;
using System.Collections;
using Sources.Infrastructure.Services.UiFramework;
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
            FormButtonViewFactory formButtonViewFactory) 
            : base(
                customFormButtonViewFactory, 
                formButtonViewFactory)
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