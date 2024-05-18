using System;
using Sources.Controllers.Presenters.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Models.Characters;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Presentations.Views.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Views.Gameplay
{
    public class ScoreCounterViewFactory
    {
        private readonly ScoreCounterPresenterFactory _presenterFactory;

        public ScoreCounterViewFactory(ScoreCounterPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IScoreCounterView Create(
            ScoreCounter scoreCounter, 
            IKillEnemyCounter killEnemyCounter, 
            ILevel level, 
            ICharacterHealth characterHealth,
            ScoreCounterView view)
        {
            ScoreCounterPresenter presenter = _presenterFactory.Create(
                scoreCounter, killEnemyCounter, level, characterHealth, view);
            view.Construct(presenter);

            return view;
        }
    }
}