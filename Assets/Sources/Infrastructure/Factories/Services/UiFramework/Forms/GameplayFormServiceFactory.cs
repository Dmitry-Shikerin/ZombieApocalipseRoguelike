using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Infrastructure.Services.UiFramework;
using Sources.InfrastructureInterfaces.Services;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.Presentation.Ui.Buttons;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.UiFramework.Buttons.Types;

namespace Sources.Infrastructure.Factories.Services.UiFramework.Forms
{
    public class GameplayFormServiceFactory : FormServiceFactoryBase
    {
        private readonly ISceneService _sceneService;
        private readonly FormService _formService;
        private readonly CustomFormButtonViewFactory _customFormButtonViewFactory;
        private readonly FormButtonViewFactory _formButtonViewFactory;
        private readonly GameplayHud _gameplayHud;

        public GameplayFormServiceFactory(
            ISceneService sceneService,
            FormService formService,
            GameplayHud gameplayHud,
            CustomFormButtonViewFactory customFormButtonViewFactory,
            FormButtonViewFactory formButtonViewFactory) 
            : base(
                customFormButtonViewFactory, 
                formButtonViewFactory)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _customFormButtonViewFactory = customFormButtonViewFactory ?? 
                                           throw new ArgumentNullException(nameof(customFormButtonViewFactory));
            _formButtonViewFactory = formButtonViewFactory ?? 
                                     throw new ArgumentNullException(nameof(formButtonViewFactory));
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
        }

        public IFormService Create()
        {
            _formService.AddButtonAction(
                ButtonId.FromPauseToMainMenuScene, 
                () => _sceneService.ChangeSceneAsync(ModelId.MainMenu));
            
            CreateFormButtons(_gameplayHud.UiCollector.UiFormButtons);

            return _formService;
        }
    }
}