using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Payloads;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Frameworks.UiFramework.PresentationsInterfaces.Buttons;
using Sources.InfrastructureInterfaces.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons
{
    public class LoadMainMenuSceneCommand : IButtonCommand
    {
        private readonly ISceneService _sceneService;
        private readonly IEntityRepository _entityRepository;

        public LoadMainMenuSceneCommand(
            ISceneService sceneService,
            IEntityRepository entityRepository)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        public ButtonCommandId Id => ButtonCommandId.LoadMainMenuScene;
        
        public void Handle(IUiButton uiButton)
        {
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            _sceneService.ChangeSceneAsync(
                ModelId.MainMenu, new ScenePayload(savedLevel.SavedLevelId, false, true));
        }
    }
}