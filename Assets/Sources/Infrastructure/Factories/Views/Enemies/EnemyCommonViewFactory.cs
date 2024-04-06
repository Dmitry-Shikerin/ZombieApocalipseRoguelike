using System;
using Sources.Domain.Enemies;
using Sources.Presentations.Views.Enemies;

namespace Sources.Infrastructure.Factories.Views.Enemies
{
    public class EnemyCommonViewFactory
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;

        public EnemyCommonViewFactory(
            EnemyViewFactory enemyViewFactory,
            EnemyHealthViewFactory enemyHealthViewFactory)
        {
            _enemyViewFactory = enemyViewFactory ?? throw new ArgumentNullException(nameof(enemyViewFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
        }

        public EnemyView Create(Enemy enemy, EnemyView enemyView)
        {
            _enemyViewFactory.Create(enemy, enemyView);
            _enemyHealthViewFactory.Create(enemy.EnemyHealth, enemyView.EnemyHealthView);

            return enemyView;
        }
    }
}