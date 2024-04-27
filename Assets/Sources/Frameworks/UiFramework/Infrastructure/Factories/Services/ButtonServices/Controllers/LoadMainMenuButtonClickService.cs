using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class LoadMainMenuButtonClickService : ICustomButtonClickService
    {
        private readonly ISceneService _sceneService;

        public LoadMainMenuButtonClickService(ISceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }

        public void OnClick(UiFormButton button)
        {
            _sceneService.ChangeSceneAsync(ModelId.MainMenu);
        }
    }
}