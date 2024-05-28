using System;
using Sources.Controllers.Presenters.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Presentations.Views.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Views.Gameplay
{
    public class KillEnemyCounterViewFactory
    {
        private readonly KillEnemyCounterPresenterFactory _presenterFactory;

        public KillEnemyCounterViewFactory(KillEnemyCounterPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IKillEnemyCounterView Create(
            KillEnemyCounter killEnemyCounter,
            IEnemySpawner enemySpawner,
            KillEnemyCounterView killEnemyCounterView)
        {
            KillEnemyCounterPresenter killEnemyCounterPresenter =
                _presenterFactory.Create(killEnemyCounter, enemySpawner, killEnemyCounterView);
            
            killEnemyCounterView.Construct(killEnemyCounterPresenter);
            
            return killEnemyCounterView;
        }
    }
}