using System;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.UiFramework;
using Sources.InfrastructureInterfaces.Services;
using Sources.Presentation.Ui.Buttons;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.UiFramework.Buttons.Types;

namespace Sources.Infrastructure.Factories.Services.UiFramevork.Forms
{
    public class GameplaySceneFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly CustomFormButtonViewFactory _customFormButtonViewFactory;
        private readonly FormButtonViewFactory _formButtonViewFactory;
        private readonly GameplayHud _gameplayHud;

        public GameplaySceneFormServiceFactory(
            FormService formService,
            GameplayHud gameplayHud,
            CustomFormButtonViewFactory customFormButtonViewFactory,
            FormButtonViewFactory formButtonViewFactory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _customFormButtonViewFactory = customFormButtonViewFactory ?? 
                                           throw new ArgumentNullException(nameof(customFormButtonViewFactory));
            _formButtonViewFactory = formButtonViewFactory ?? 
                                     throw new ArgumentNullException(nameof(formButtonViewFactory));
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
        }

        public IFormService Create()
        {
            
            
            foreach (UiFormButton formButton in _gameplayHud.UiCollector.UiFormButtons)
            {
                if (formButton.ButtonType == ButtonType.Default)
                    _formButtonViewFactory.Create(formButton);
                else if (formButton.ButtonType == ButtonType.Custom)
                    _customFormButtonViewFactory.Create(formButton);
            }

            return _formService;
        }
    }
}