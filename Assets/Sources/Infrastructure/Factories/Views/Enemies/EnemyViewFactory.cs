using System;
using Sources.Controllers.Enemies;
using Sources.Domain.Enemies;
using Sources.Infrastructure.Factories.Controllers.Enemies;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Infrastructure.Factories.Views.Enemies
{
    public class EnemyViewFactory
    {
        private readonly EnemyPresenterFactory _enemyPresenterFactory;

        public EnemyViewFactory(EnemyPresenterFactory enemyPresenterFactory)
        {
            _enemyPresenterFactory = enemyPresenterFactory ??
                                     throw new ArgumentNullException(nameof(enemyPresenterFactory));
        }

        public IEnemyView Create(Enemy enemy, EnemyView enemyView)
        {
            EnemyPresenter enemyPresenter = _enemyPresenterFactory.Create(enemy, enemyView);
            
            enemyView.Construct(enemyPresenter);
            
            return enemyView;
        }
    }
}