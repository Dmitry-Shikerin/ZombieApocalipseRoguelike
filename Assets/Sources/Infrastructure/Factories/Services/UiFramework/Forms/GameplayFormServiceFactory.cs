using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Services.Forms;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Factories.Services.UiFramework.Forms
{
    public class GameplayFormServiceFactory : FormServiceFactoryBase
    {
        private readonly IPauseService _pauseService;
        private readonly ISceneService _sceneService;
        private readonly FormService _formService;
        private readonly GameplayHud _gameplayHud;

        public GameplayFormServiceFactory(
            IPauseService pauseService,
            ISceneService sceneService,
            FormService formService,
            GameplayHud gameplayHud,
            CustomFormButtonViewFactory customFormButtonViewFactory,
            FormButtonViewFactory formButtonViewFactory,
            UiContainerFactory uiContainerFactory) 
            : base(
                customFormButtonViewFactory, 
                formButtonViewFactory,
                uiContainerFactory)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));;
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
        }

        public IFormService Create()
        {
            //MainMenu
            _formService.AddButtonAction(
                ButtonId.FromPauseToMainMenuScene, 
                () => _sceneService.ChangeSceneAsync(ModelId.MainMenu));
            
            //Pause
            // _formService.AddFormButtonEnabledAction(FormId.Pause, (button) =>
            // {
            //     Debug.Log("Pause");
            //     // _pauseService.Pause();
            // });
            // _formService.AddFormButtonDisabledAction(FormId.Pause, (button) =>
            // {
            //     Debug.Log("Continue");
            //     // _pauseService.Continue();
            // });
            
            CreateFormButtons(_gameplayHud.UiCollector.UiFormButtons);
            CreateUiContainers(_gameplayHud.UiCollector.UiContainers);

            return _formService;
        }
    }
}