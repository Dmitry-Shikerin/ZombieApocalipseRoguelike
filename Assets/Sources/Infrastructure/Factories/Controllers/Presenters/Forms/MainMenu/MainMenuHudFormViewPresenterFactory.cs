using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class MainMenuHudFormViewPresenterFactory
    {
        private readonly IFormService _formService;

        public MainMenuHudFormViewPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public MainMenuHudFormPresenter Create(IMainMenuHudFormView view)
        {
            return new MainMenuHudFormPresenter(view, _formService);
        }
    }
}