using System;
using Sources.Controllers.Presenters.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay
{
    public class LevelAvailabilityPresenterFactory
    {
        private readonly ISceneService _sceneService;

        public LevelAvailabilityPresenterFactory(ISceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public LevelAvailabilityPresenter Create(
            LevelAvailability levelAvailability,
            ILevelAvailabilityView levelAvailabilityView)
        {
            return new LevelAvailabilityPresenter(levelAvailability, levelAvailabilityView, _sceneService);
        }
    }
}