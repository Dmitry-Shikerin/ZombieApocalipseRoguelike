using System;
using Sources.Domain.Enemies;
using Sources.Infrastructure.Factories.Controllers.Common;
using Sources.Presentations.Views.Enemies;

namespace Sources.Infrastructure.Factories.Views.Enemies
{
    public class EnemyCommonViewFactory
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUiPresenterFactory _healthUiPresenterFactory;

        public EnemyCommonViewFactory(
            EnemyViewFactory enemyViewFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUiPresenterFactory healthUiPresenterFactory)
        {
            _enemyViewFactory = enemyViewFactory ?? throw new ArgumentNullException(nameof(enemyViewFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUiPresenterFactory = healthUiPresenterFactory ?? 
                                        throw new ArgumentNullException(nameof(healthUiPresenterFactory));
        }

        public EnemyView Create(Enemy enemy, EnemyView enemyView)
        {
            _enemyViewFactory.Create(enemy, enemyView);
            _enemyHealthViewFactory.Create(enemy.EnemyHealth, enemyView.EnemyHealthView);
            _healthUiPresenterFactory.Create(enemy.EnemyHealth, enemyView.HealthUi);

            return enemyView;
        }
    }
}