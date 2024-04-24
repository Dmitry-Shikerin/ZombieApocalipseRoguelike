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
        private readonly MainMenuSettingsFormFactory _mainMenuSettingsFormFactory;
        private readonly AuthorizationFormFactory _authorizationFormFactory;
        private readonly LeaderboardFormFactory _leaderboardFormFactory;
        private readonly IBindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm> _mainMenuHudFormBuilder;
        private readonly IBindableViewBuilder<MainMenuSettingsFormViewModel, MainMenuSettingsForm> _mainMenuSettingsFormBuilder;
        private readonly IBindableViewBuilder<AuthorizationFormViewModel, AuthorizationForm> _authorizationFormBuilder;
        private readonly IBindableViewBuilder<LeaderboardFormViewModel, LeaderboardForm> _leaderboardFormBuilder;
        private readonly MainMenuHud _mainMenuHud;

        public MainMenuFormServiceFactory(
            FormService formService,
            MainMenuHud mainMenuHud,
            MainMenuHudFormFactory mainMenuHudFormFactory,
            MainMenuSettingsFormFactory mainMenuSettingsFormFactory,
            AuthorizationFormFactory authorizationFormFactory,
            LeaderboardFormFactory leaderboardFormFactory,
            IBindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm> mainMenuHudFormBuilder,
            IBindableViewBuilder<MainMenuSettingsFormViewModel, MainMenuSettingsForm> mainMenuSettingsFormBuilder,
            IBindableViewBuilder<AuthorizationFormViewModel, AuthorizationForm> authorizationFormBuilder,
            IBindableViewBuilder<LeaderboardFormViewModel, LeaderboardForm> leaderboardFormBuilder)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _mainMenuHudFormFactory = mainMenuHudFormFactory ?? throw new ArgumentNullException(nameof(mainMenuHudFormFactory));
            _mainMenuSettingsFormFactory = mainMenuSettingsFormFactory ?? throw new ArgumentNullException(nameof(mainMenuSettingsFormFactory));
            _authorizationFormFactory = authorizationFormFactory ?? throw new ArgumentNullException(nameof(authorizationFormFactory));
            _leaderboardFormFactory = leaderboardFormFactory ?? throw new ArgumentNullException(nameof(leaderboardFormFactory));
            _mainMenuHudFormBuilder = mainMenuHudFormBuilder ?? throw new ArgumentNullException(nameof(mainMenuHudFormBuilder));
            _mainMenuSettingsFormBuilder = mainMenuSettingsFormBuilder ?? throw new ArgumentNullException(nameof(mainMenuSettingsFormBuilder));
            _authorizationFormBuilder = authorizationFormBuilder ?? throw new ArgumentNullException(nameof(authorizationFormBuilder));
            _leaderboardFormBuilder = leaderboardFormBuilder ?? throw new ArgumentNullException(nameof(leaderboardFormBuilder));
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
        }

        public IFormService Create()
        {
            MainMenuHudForm mainMenuHudForm = _mainMenuHudFormFactory.Create();
            _mainMenuHudFormBuilder.Build(mainMenuHudForm, _mainMenuHud.MainMenuHudFormBindableView);
            _formService.Register<MainMenuHudForm>(mainMenuHudForm);

            MainMenuSettingsForm mainMenuSettingsForm = _mainMenuSettingsFormFactory.Create();
            _mainMenuSettingsFormBuilder.Build(mainMenuSettingsForm, _mainMenuHud.MainMenuSettingsFormBindableView);
            _formService.Register<MainMenuSettingsForm>(mainMenuSettingsForm);

            AuthorizationForm authorizationForm = _authorizationFormFactory.Create();
            _authorizationFormBuilder.Build(authorizationForm, _mainMenuHud.AuthorizationFormBindableView);
            _formService.Register<AuthorizationForm>(authorizationForm);

            LeaderboardForm leaderboardForm = _leaderboardFormFactory.Create();
            _leaderboardFormBuilder.Build(leaderboardForm, _mainMenuHud.LeaderboardFormBindableView);
            _formService.Register<LeaderboardForm>(leaderboardForm);

            return _formService;
        }
    }
}