using System;
using Sources.Domain.Enemies;
using Sources.Infrastructure.Factories.Controllers.Common;
using Sources.Infrastructure.Factories.Views.Commons;
using Sources.Presentations.Views.Enemies;

namespace Sources.Infrastructure.Factories.Views.Enemies
{
    public class EnemyCommonViewFactory
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUiFactory _healthUiFactory;

        public EnemyCommonViewFactory(
            EnemyViewFactory enemyViewFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUiFactory healthUiFactory)
        {
            _enemyViewFactory = enemyViewFactory ?? throw new ArgumentNullException(nameof(enemyViewFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUiFactory = healthUiFactory ?? throw new ArgumentNullException(nameof(healthUiFactory));
        }

        public EnemyView Create(Enemy enemy, EnemyView enemyView)
        {
            _enemyViewFactory.Create(enemy, enemyView);
            _enemyHealthViewFactory.Create(enemy.EnemyHealth, enemyView.EnemyHealthView);
            _healthUiFactory.Create(enemy.EnemyHealth, enemyView.HealthUi);

            return enemyView;
        }
    }
}