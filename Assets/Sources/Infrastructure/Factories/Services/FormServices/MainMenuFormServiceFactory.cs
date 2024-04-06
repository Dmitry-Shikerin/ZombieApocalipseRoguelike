using System;
using Assets.Sources.InfastructureInterfaces.Services.Forms;
using Assets.Sources.Infrastructure.Services.Forms;
using JetBrains.Annotations;
using Sources.Controllers.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.Forms.MainMenu;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.Common;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class MainMenuFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly MainMenuHud _mainMenuHud;
        private readonly MainMenuHudFormPresenterFactory _mainMenuHudFormPresenterFactory;
        private readonly SettingsFormPresenterFactory _settingsFormPresenterFactory;
        private readonly AuthorizationFormPresenterFactory _authorizationFormPresenterFactory;

        public MainMenuFormServiceFactory(
            FormService formService,
            MainMenuHud mainMenuHud,
            MainMenuHudFormPresenterFactory mainMenuHudFormPresenterFactory,
            SettingsFormPresenterFactory settingsFormPresenterFactory,
            AuthorizationFormPresenterFactory authorizationFormPresenterFactory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _mainMenuHudFormPresenterFactory = mainMenuHudFormPresenterFactory ??
                                               throw new ArgumentNullException(nameof(mainMenuHudFormPresenterFactory));
            _settingsFormPresenterFactory = settingsFormPresenterFactory ??
                                            throw new ArgumentNullException(nameof(settingsFormPresenterFactory));
            _authorizationFormPresenterFactory = authorizationFormPresenterFactory ??
                                                 throw new ArgumentNullException(nameof(authorizationFormPresenterFactory));
        }

        public IFormService Create()
        {
            Form<MainMenuHudFormView, MainMenuHudFormPresenter> mainMenuHudForm =
                new Form<MainMenuHudFormView, MainMenuHudFormPresenter>(
                    _mainMenuHudFormPresenterFactory.Create, _mainMenuHud.MainMenuHudFormView);
            
            _formService.Add(mainMenuHudForm);

            Form<SettingsFormView, SettingsFormPresenter> settingsForm =
                new Form<SettingsFormView, SettingsFormPresenter>(
                    _settingsFormPresenterFactory.Create, _mainMenuHud.SettingsFormView);
            
            _formService.Add(settingsForm);

            Form<AuthorizationFormView, AuthorizationFormPresenter> authorizationForm =
                new Form<AuthorizationFormView, AuthorizationFormPresenter>(
                    _authorizationFormPresenterFactory.Create, _mainMenuHud.AuthorizationFormView);
            
            _formService.Add(authorizationForm);

            return _formService;
        }
    }
}