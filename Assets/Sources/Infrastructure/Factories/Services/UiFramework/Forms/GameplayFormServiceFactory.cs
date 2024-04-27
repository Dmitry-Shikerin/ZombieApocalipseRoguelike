using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Services.Forms;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Factories.Services.UiFramework.Forms
{
    public class GameplayFormServiceFactory : FormServiceFactoryBase
    {
        private readonly ISceneService _sceneService;
        private readonly FormService _formService;
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
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));;
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