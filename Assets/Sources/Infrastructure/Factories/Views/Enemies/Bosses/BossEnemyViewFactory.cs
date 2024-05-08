using System;
using Sources.Controllers.Presenters.Enemies.Base;
using Sources.Domain.Models.Enemies.Bosses;
using Sources.Domain.Models.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Enemies.Bosses;
using Sources.Infrastructure.Factories.Views.Commons;
using Sources.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.Presentations.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Enemies.Bosses
{
    public class BossEnemyViewFactory : IBossEnemyViewFactory
    {
        private readonly BossEnemyPresenterFactory _bossEnemyPresenterFactory;
        private readonly IObjectPool<BossEnemyView> _bossEnemyPool;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUiFactory _healthUiFactory;
        private readonly HealthUiTextViewFactory _healthUiTextViewFactory;

        public BossEnemyViewFactory(
            BossEnemyPresenterFactory bossEnemyPresenterFactory,
            IObjectPool<BossEnemyView> bossEnemyPool,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUiFactory healthUiFactory,
            HealthUiTextViewFactory healthUiTextViewFactory)
        {
            _bossEnemyPresenterFactory = bossEnemyPresenterFactory ??
                                         throw new ArgumentNullException(nameof(bossEnemyPresenterFactory));
            _bossEnemyPool = bossEnemyPool ?? throw new ArgumentNullException(nameof(bossEnemyPool));
            _enemyHealthViewFactory = enemyHealthViewFactory ?? 
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUiFactory = healthUiFactory ?? throw new ArgumentNullException(nameof(healthUiFactory));
            _healthUiTextViewFactory = healthUiTextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUiTextViewFactory));
        }

        public IBossEnemyView Create(BossEnemy bossEnemy, KillEnemyCounter killEnemyCounter)
        {
            BossEnemyView bossEnemyView = CreateView();
            
            return Create(bossEnemy, killEnemyCounter, bossEnemyView);
        }
        
        public IBossEnemyView Create(BossEnemy bossEnemy, KillEnemyCounter killEnemyCounter, BossEnemyView bossEnemyView)
        {
            EnemyPresenter enemyPresenter = _bossEnemyPresenterFactory.Create(
                bossEnemy, killEnemyCounter, bossEnemyView, bossEnemyView.EnemyAnimation);
            
            bossEnemyView.Construct(enemyPresenter);
            
            _enemyHealthViewFactory.Create(bossEnemy.EnemyHealth, bossEnemyView.EnemyHealthView);
            _healthUiFactory.Create(bossEnemy.EnemyHealth, bossEnemyView.HealthUi);
            _healthUiTextViewFactory.Create(bossEnemy.EnemyHealth, bossEnemyView.HealthUiText);

            return bossEnemyView;
        }

        private BossEnemyView CreateView()
        {
            BossEnemyView bossEnemyView = Object.Instantiate(
                Resources.Load<BossEnemyView>("Views/BossEnemyView"));
            //TODO не забыть поменять
            // EnemyView enemyView = Object.FindObjectOfType<EnemyView>();

            bossEnemyView
                .AddComponent<PoolableObject>()
                .SetPool(_bossEnemyPool);

            return bossEnemyView;
        }
    }
}