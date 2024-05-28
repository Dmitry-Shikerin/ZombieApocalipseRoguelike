﻿using System;
using Sources.Controllers.Presenters.Enemies;
using Sources.Domain.Models.Enemies;
using Sources.Infrastructure.Factories.Controllers.Presenters.Enemies;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Infrastructure.Factories.Views.Enemies
{
    public class EnemyHealthViewFactory
    {
        private readonly EnemyHealthPresenterFactory _enemyHealthPresenterFactory;

        public EnemyHealthViewFactory(EnemyHealthPresenterFactory enemyHealthPresenterFactory)
        {
            _enemyHealthPresenterFactory = enemyHealthPresenterFactory ?? 
                                           throw new ArgumentNullException(nameof(enemyHealthPresenterFactory));
        }

        public IEnemyHealthView Create(EnemyHealth enemyHealth, EnemyHealthView enemyHealthView)
        {
            EnemyHealthPresenter enemyHealthPresenter =
                _enemyHealthPresenterFactory.Create(enemyHealth, enemyHealthView);
            
            enemyHealthView.Construct(enemyHealthPresenter);
            
            return enemyHealthView;
        }
    }
}