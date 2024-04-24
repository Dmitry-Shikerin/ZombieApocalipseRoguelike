﻿using System;
using Sources.Controllers.Gameplay;
using Sources.Domain.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Spawners;
using Sources.Infrastructure.Factories.Controllers.Gameplay;
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
            EnemySpawner enemySpawner,
            KillEnemyCounterView killEnemyCounterView)
        {
            KillEnemyCounterPresenter killEnemyCounterPresenter =
                _presenterFactory.Create(killEnemyCounter, enemySpawner, killEnemyCounterView);
            
            killEnemyCounterView.Construct(killEnemyCounterPresenter);
            
            return killEnemyCounterView;
        }
    }
}