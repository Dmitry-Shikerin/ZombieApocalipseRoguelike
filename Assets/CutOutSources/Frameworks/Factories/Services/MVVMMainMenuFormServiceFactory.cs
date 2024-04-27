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
    public class MVVMMainMenuFormServiceFactory
    {
        private readonly DomainFormService _domainFormService;
        private readonly MainMenuHudFormFactory _mainMenuHudFormFactory;
        private readonly MainMenuSettingsFormFactory _mainMenuSettingsFormFactory;
        private readonly AuthorizationFormFactory _authorizationFormFactory;
        private readonly LeaderboardFormFactory _leaderboardFormFactory;
        private readonly NewGameFormFactory _newGameFormFactory;
        private readonly WarningNewGameFormFactory _warningNewGameFormFactory;
        private readonly IBindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm> _mainMenuHudFormBuilder;
        private readonly IBindableViewBuilder<MainMenuSettingsFormViewModel, MainMenuSettingsForm> _mainMenuSettingsFormBuilder;
        private readonly IBindableViewBuilder<AuthorizationFormViewModel, AuthorizationForm> _authorizationFormBuilder;
        private readonly IBindableViewBuilder<LeaderboardFormViewModel, LeaderboardForm> _leaderboardFormBuilder;
        private readonly IBindableViewBuilder<NewGameFormViewModel, NewGameForm> _newGameFormBuilder;
        private readonly IBindableViewBuilder<WarningNewGameFormViewModel, WarningNewGameForm> _warningNewGameFormBuilder;
        private readonly MainMenuHud _mainMenuHud;

        public MVVMMainMenuFormServiceFactory(
            DomainFormService domainFormService,
            MainMenuHud mainMenuHud,
            MainMenuHudFormFactory mainMenuHudFormFactory,
            MainMenuSettingsFormFactory mainMenuSettingsFormFactory,
            AuthorizationFormFactory authorizationFormFactory,
            LeaderboardFormFactory leaderboardFormFactory,
            NewGameFormFactory newGameFormFactory,
            WarningNewGameFormFactory warningNewGameFormFactory,
            IBindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm> mainMenuHudFormBuilder,
            IBindableViewBuilder<MainMenuSettingsFormViewModel, MainMenuSettingsForm> mainMenuSettingsFormBuilder,
            IBindableViewBuilder<AuthorizationFormViewModel, AuthorizationForm> authorizationFormBuilder,
            IBindableViewBuilder<LeaderboardFormViewModel, LeaderboardForm> leaderboardFormBuilder,
            IBindableViewBuilder<NewGameFormViewModel, NewGameForm> newGameFormBuilder,
            IBindableViewBuilder<WarningNewGameFormViewModel, WarningNewGameForm> warningNewGameFormBuilder)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
            _mainMenuHudFormFactory = mainMenuHudFormFactory ?? throw new ArgumentNullException(nameof(mainMenuHudFormFactory));
            _mainMenuSettingsFormFactory = mainMenuSettingsFormFactory ?? throw new ArgumentNullException(nameof(mainMenuSettingsFormFactory));
            _authorizationFormFactory = authorizationFormFactory ?? throw new ArgumentNullException(nameof(authorizationFormFactory));
            _leaderboardFormFactory = leaderboardFormFactory ?? throw new ArgumentNullException(nameof(leaderboardFormFactory));
            _newGameFormFactory = newGameFormFactory ?? throw new ArgumentNullException(nameof(newGameFormFactory));
            _warningNewGameFormFactory = warningNewGameFormFactory ?? throw new ArgumentNullException(nameof(warningNewGameFormFactory));
            _mainMenuHudFormBuilder = mainMenuHudFormBuilder ?? throw new ArgumentNullException(nameof(mainMenuHudFormBuilder));
            _mainMenuSettingsFormBuilder = mainMenuSettingsFormBuilder ?? throw new ArgumentNullException(nameof(mainMenuSettingsFormBuilder));
            _authorizationFormBuilder = authorizationFormBuilder ?? throw new ArgumentNullException(nameof(authorizationFormBuilder));
            _leaderboardFormBuilder = leaderboardFormBuilder ?? throw new ArgumentNullException(nameof(leaderboardFormBuilder));
            _newGameFormBuilder = newGameFormBuilder ?? throw new ArgumentNullException(nameof(newGameFormBuilder));
            _warningNewGameFormBuilder = warningNewGameFormBuilder ?? throw new ArgumentNullException(nameof(warningNewGameFormBuilder));
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
        }

        public IDomainFormService Create()
        {
            // MainMenuHudForm mainMenuHudForm = _mainMenuHudFormFactory.Create();
            // _mainMenuHudFormBuilder.Build(mainMenuHudForm, _mainMenuHud.MainMenuHudFormBindableView);
            // _domainFormService.Register<MainMenuHudForm>(mainMenuHudForm);
            //
            // MainMenuSettingsForm mainMenuSettingsForm = _mainMenuSettingsFormFactory.Create();
            // _mainMenuSettingsFormBuilder.Build(mainMenuSettingsForm, _mainMenuHud.MainMenuSettingsFormBindableView);
            // _domainFormService.Register<MainMenuSettingsForm>(mainMenuSettingsForm);
            //
            // AuthorizationForm authorizationForm = _authorizationFormFactory.Create();
            // _authorizationFormBuilder.Build(authorizationForm, _mainMenuHud.AuthorizationFormBindableView);
            // _domainFormService.Register<AuthorizationForm>(authorizationForm);
            //
            // LeaderboardForm leaderboardForm = _leaderboardFormFactory.Create();
            // _leaderboardFormBuilder.Build(leaderboardForm, _mainMenuHud.LeaderboardFormBindableView);
            // _domainFormService.Register<LeaderboardForm>(leaderboardForm);
            //
            // NewGameForm newGameForm = _newGameFormFactory.Create();
            // _newGameFormBuilder.Build(newGameForm, _mainMenuHud.NewGameFormBindableView);
            // _domainFormService.Register<NewGameForm>(newGameForm);
            //
            // WarningNewGameForm warningNewGameForm = _warningNewGameFormFactory.Create();
            // _warningNewGameFormBuilder.Build(warningNewGameForm, _mainMenuHud.WarningNewGameFormBindableView);
            // _domainFormService.Register<WarningNewGameForm>(warningNewGameForm);

            return _domainFormService;
        }
    }
}