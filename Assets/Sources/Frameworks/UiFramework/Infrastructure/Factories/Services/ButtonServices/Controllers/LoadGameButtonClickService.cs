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
    public class LoadGameButtonClickService : ICustomButtonClickService
    {
        private readonly ISceneService _sceneService;
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;

        public LoadGameButtonClickService(
            ISceneService sceneService,
            ILoadService loadService,
            IEntityRepository entityRepository)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        public void Enable(UiButton button)
        {
            button.Show();

            if (_loadService.HasKey(ModelId.PlayerWallet) == false)
                button.Hide();
        }

        public void Disable(UiButton button)
        {
        }

        public void OnClick(UiButton button)
        {
            if (_loadService.HasKey(ModelId.PlayerWallet) == false)
                return;

            SavedLevel savedLevel = _entityRepository.Get(ModelId.SavedLevel) as SavedLevel;

            _sceneService.ChangeSceneAsync(
                savedLevel.SavedLevelId,
                new ScenePayload(savedLevel.SavedLevelId, true));
        }
    }
}