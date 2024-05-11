﻿using Sources.Controllers.Presenters.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Gameplay
{
    public class KillEnemyCounterPresenterFactory
    {
        public KillEnemyCounterPresenter Create(
            KillEnemyCounter killEnemyCounter,
            IEnemySpawner enemySpawner,
            IKillEnemyCounterView killEnemyCounterView)
        {
            return new KillEnemyCounterPresenter(killEnemyCounter, enemySpawner, killEnemyCounterView);
        }
    }
}