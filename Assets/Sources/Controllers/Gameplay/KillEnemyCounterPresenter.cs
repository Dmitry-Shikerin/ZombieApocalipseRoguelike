using System;
using Sources.Controllers.Common;
using Sources.Domain.Gameplay;
using Sources.Domain.Spawners;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Controllers.Gameplay
{
    public class KillEnemyCounterPresenter : PresenterBase
    {
        private readonly KillEnemyCounter _killEnemyCounter;
        private readonly EnemySpawner _enemySpawner;
        private readonly IKillEnemyCounterView _killEnemyCounterView;

        public KillEnemyCounterPresenter(
            KillEnemyCounter killEnemyCounter,
            EnemySpawner enemySpawner,
            IKillEnemyCounterView killEnemyCounterView)
        {
            _killEnemyCounter = killEnemyCounter ?? 
                                throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _killEnemyCounterView = killEnemyCounterView ??
                                    throw new ArgumentNullException(nameof(killEnemyCounterView));
        }

        public override void Enable()
        {
            OnKillZombieCountChanged();
            _killEnemyCounter.KillZombiesCountChanged += OnKillZombieCountChanged;
        }

        public override void Disable()
        {
            _killEnemyCounter.KillZombiesCountChanged -= OnKillZombieCountChanged;
        }

        //TODO очень похож на HealthUI
        private void OnKillZombieCountChanged()
        {
            float percent = _enemySpawner.SumEnemies / 100f;
            int currentPercents = 0;
            float currentHealth = 0;

            while (currentHealth < _killEnemyCounter.KillZombies)
            {
                currentHealth += percent;
                currentPercents++;
            }
            
            _killEnemyCounterView.KillEnemyBar.SetFillAmount(currentPercents * 0.01f);
        }
    }
}