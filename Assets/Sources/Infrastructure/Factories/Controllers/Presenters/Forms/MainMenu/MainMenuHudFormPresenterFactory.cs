using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Forms.MainMenu
{
    public class MainMenuHudFormPresenterFactory
    {
        private readonly IViewFormService _viewFormService;

        public MainMenuHudFormPresenterFactory(IViewFormService viewFormService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public MainMenuHudFormPresenter Create(IMainMenuHudFormView mainMenuHudFormView)
        {
            if (mainMenuHudFormView == null)
                throw new ArgumentNullException(nameof(mainMenuHudFormView));

            return new MainMenuHudFormPresenter(_viewFormService, mainMenuHudFormView);
        }
    }
}