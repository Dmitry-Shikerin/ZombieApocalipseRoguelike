using System;
using Sources.Controllers.Enemies.Base;
using Sources.Domain.Enemies;
using Sources.Domain.Enemies.Base;
using Sources.Domain.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Enemies.Base;
using Sources.Infrastructure.Factories.Views.Commons;
using Sources.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Enemies.Base
{
    public class EnemyViewFactory : IEnemyViewFactory
    {
        private readonly EnemyPresenterFactory _enemyPresenterFactory;
        private readonly IObjectPool<EnemyView> _enemyPool;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUiFactory _healthUiFactory;

        public EnemyViewFactory(
            EnemyPresenterFactory enemyPresenterFactory,
            IObjectPool<EnemyView> enemyPool,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUiFactory healthUiFactory)
        {
            _enemyPresenterFactory = enemyPresenterFactory ??
                                     throw new ArgumentNullException(nameof(enemyPresenterFactory));
            _enemyPool = enemyPool ?? throw new ArgumentNullException(nameof(enemyPool));
            _enemyHealthViewFactory = enemyHealthViewFactory ?? 
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUiFactory = healthUiFactory ?? throw new ArgumentNullException(nameof(healthUiFactory));
        }

        public IEnemyView Create(Enemy enemy, KillEnemyCounter killEnemyCounter)
        {
            EnemyView enemyView = CreateView();
            
            return Create(enemy, killEnemyCounter, enemyView);
        }

        public IEnemyView Create(Enemy enemy, KillEnemyCounter killEnemyCounter, EnemyView enemyView)
        {
            EnemyPresenter enemyPresenter = _enemyPresenterFactory.Create(
                enemy, killEnemyCounter, enemyView, enemyView.EnemyAnimation);
            
            enemyView.Construct(enemyPresenter);
            
            _enemyHealthViewFactory.Create(enemy.EnemyHealth, enemyView.EnemyHealthView);
            _healthUiFactory.Create(enemy.EnemyHealth, enemyView.HealthUi);
            
            return enemyView;
        }

        private EnemyView CreateView()
        {
            EnemyView enemyView = Object.Instantiate(
                Resources.Load<EnemyView>("Views/EnemyView"));
            //TODO не забыть поменять
            // EnemyView enemyView = Object.FindObjectOfType<EnemyView>();

            enemyView
                .AddComponent<PoolableObject>()
                .SetPool(_enemyPool);

            return enemyView;
        }
    }
}