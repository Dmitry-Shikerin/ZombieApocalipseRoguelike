using System;
using Sources.Controllers.Enemies.Base;
using Sources.Domain.Enemies.Bosses;
using Sources.Infrastructure.Factories.Controllers.Enemies.Bosses;
using Sources.Presentations.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Infrastructure.Factories.Views.Enemies.Bosses
{
    public class BossEnemyViewFactory
    {
        private readonly BossEnemyPresenterFactory _bossEnemyPresenterFactory;

        public BossEnemyViewFactory(BossEnemyPresenterFactory bossEnemyPresenterFactory)
        {
            _bossEnemyPresenterFactory = bossEnemyPresenterFactory ??
                                         throw new ArgumentNullException(nameof(bossEnemyPresenterFactory));
        }

        public IBossEnemyView Create(BossEnemy bossEnemy, BossEnemyView bossEnemyView)
        {
            EnemyPresenter enemyPresenter = _bossEnemyPresenterFactory.Create(
                bossEnemy, bossEnemyView, bossEnemyView.EnemyAnimation);
            
            bossEnemyView.Construct(enemyPresenter);

            return bossEnemyView;
        }
    }
}