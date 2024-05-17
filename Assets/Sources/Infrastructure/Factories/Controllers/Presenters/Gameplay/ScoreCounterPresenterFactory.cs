using Sources.Controllers.Presenters.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay
{
    public class ScoreCounterPresenterFactory
    {
        public ScoreCounterPresenter Create(
            ScoreCounter scoreCounter, 
            IKillEnemyCounter killEnemyCounter, 
            ILevel level, 
            IScoreCounterView view)
        {
            return new ScoreCounterPresenter(scoreCounter, killEnemyCounter, level, view);
        }
    }
}