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
        private readonly CustomFormButtonViewFactory _customFormButtonViewFactory;
        private readonly FormButtonViewFactory _formButtonViewFactory;

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
            _customFormButtonViewFactory = customFormButtonViewFactory ?? throw new ArgumentNullException(nameof(customFormButtonViewFactory));
            _formButtonViewFactory = formButtonViewFactory ?? throw new ArgumentNullException(nameof(formButtonViewFactory));
        }

        public IFormService Create()
        {
            CreateFormButtons(_mainMenuHud.UiCollector.UiFormButtons);            

            return _formService;
        }
    }
}