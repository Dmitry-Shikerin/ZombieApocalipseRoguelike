using System;
using Sources.Controllers.Gameplay;
using Sources.Controllers.Presenters.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Gameplay;
using Sources.Presentations.Views.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Views.Gameplay
{
    public class LevelAvailabilityViewFactory
    {
        private readonly LevelAvailabilityPresenterFactory _presenterFactory;

        public LevelAvailabilityViewFactory(LevelAvailabilityPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public ILevelAvailabilityView Create(
            LevelAvailability levelAvailability,
            LevelAvailabilityView levelAvailabilityView)
        {
            LevelAvailabilityPresenter presenter = _presenterFactory.Create(levelAvailability, levelAvailabilityView);
            
            levelAvailabilityView.Construct(presenter);
            
            return levelAvailabilityView;
        }
    }
}