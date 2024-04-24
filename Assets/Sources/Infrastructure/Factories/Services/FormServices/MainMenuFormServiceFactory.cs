using System;
using Sources.Controllers.ModelViews.Forms.MainMenu;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Domain.Forms.MainMenu;
using Sources.Infrastructure.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class MainMenuFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly MainMenuHudFormFactory _mainMenuHudFormFactory;
        private readonly IBindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm> _mainMenuHudFormBuilder;
        private readonly MainMenuHud _mainMenuHud;

        public MainMenuFormServiceFactory(
            FormService formService,
            MainMenuHud mainMenuHud,
            MainMenuHudFormFactory mainMenuHudFormFactory,
            IBindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm> mainMenuHudFormBuilder)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _mainMenuHudFormFactory = mainMenuHudFormFactory ?? throw new ArgumentNullException(nameof(mainMenuHudFormFactory));
            _mainMenuHudFormBuilder = mainMenuHudFormBuilder ?? throw new ArgumentNullException(nameof(mainMenuHudFormBuilder));
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
        }

        public IFormService Create()
        {
            MainMenuHudForm mainMenuHudForm = _mainMenuHudFormFactory.Create();
            _mainMenuHudFormBuilder.Build(mainMenuHudForm, _mainMenuHud.MainMenuHudFormBindableView);
            _formService.Register<MainMenuHudForm>(mainMenuHudForm);

            return _formService;
        }
    }
}