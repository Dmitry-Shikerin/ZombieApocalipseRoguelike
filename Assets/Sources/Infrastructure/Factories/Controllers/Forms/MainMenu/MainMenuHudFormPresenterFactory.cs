using System;
using Assets.Sources.InfastructureInterfaces.Services.Forms;
using JetBrains.Annotations;
using Sources.Controllers.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Forms.MainMenu
{
    public class MainMenuHudFormPresenterFactory
    {
        private readonly IFormService _formService;

        public MainMenuHudFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public MainMenuHudFormPresenter Create(IMainMenuHudFormView mainMenuHudFormView)
        {
            if (mainMenuHudFormView == null)
                throw new ArgumentNullException(nameof(mainMenuHudFormView));

            return new MainMenuHudFormPresenter(_formService, mainMenuHudFormView);
        }
    }
}