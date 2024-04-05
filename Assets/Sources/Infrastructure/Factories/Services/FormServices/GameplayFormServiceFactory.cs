using System;
using Assets.Sources.InfastructureInterfaces.Services.Forms;
using Assets.Sources.Infrastructure.Services.Forms;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.Common;
using Sources.Presentations.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class GameplayFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly GameplayHud _gameplayHud;
        private readonly PauseFormPresenterFactory _pauseFormPresenterFactory;
        private readonly HudFormPresenterFactory _hudFormPresenterFactory;

        public GameplayFormServiceFactory(
            FormService formService,
            GameplayHud gameplayHud,
            PauseFormPresenterFactory pauseFormPresenterFactory,
            HudFormPresenterFactory hudFormPresenterFactory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _pauseFormPresenterFactory = pauseFormPresenterFactory ?? 
                                         throw new ArgumentNullException(nameof(pauseFormPresenterFactory));
            _hudFormPresenterFactory = hudFormPresenterFactory ?? 
                                       throw new ArgumentNullException(nameof(hudFormPresenterFactory));
        }

        public IFormService Create()
        {
            Form<PauseFormView, PauseFormPresenter> pauseForm = 
                new Form<PauseFormView, PauseFormPresenter>(
                    _pauseFormPresenterFactory.Create, _gameplayHud.PauseFormView);
            _formService.Add(pauseForm);

            Form<HudFormView, HudFormPresenter> hudForm =
                new Form<HudFormView, HudFormPresenter>(
                    _hudFormPresenterFactory.Create, _gameplayHud.HudFormView);
            _formService.Add(hudForm);
            
            return _formService;
        }
    }
}