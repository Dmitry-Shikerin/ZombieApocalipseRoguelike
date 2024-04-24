using Sources.Controllers.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Gameplay
{
    public class LevelAvailabilityPresenterFactory
    {
        public LevelAvailabilityPresenter Create(
            LevelAvailability levelAvailability,
            ILevelAvailabilityView levelAvailabilityView)
        {
            return new LevelAvailabilityPresenter(levelAvailability, levelAvailabilityView);
        }
    }
}