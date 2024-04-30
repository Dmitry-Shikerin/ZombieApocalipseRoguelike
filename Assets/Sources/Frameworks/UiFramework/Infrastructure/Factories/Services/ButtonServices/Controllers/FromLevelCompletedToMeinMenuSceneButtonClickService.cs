using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Payloads;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class FromLevelCompletedToMeinMenuSceneButtonClickService : ICustomButtonClickService
    {
        private readonly ISceneService _sceneService;
        private readonly IEntityRepository _entityRepository;
        private readonly ILoadService _loadService;

        public FromLevelCompletedToMeinMenuSceneButtonClickService(
            ISceneService sceneService,
            IEntityRepository entityRepository)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        public void Enable(UiButton button)
        {
        }

        public void Disable(UiButton button)
        {
        }

        public void OnClick(UiButton button)
        {
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            _sceneService.ChangeSceneAsync(ModelId.MainMenu, new ScenePayload(savedLevel.SavedLevelId, false));
        }
    }
}