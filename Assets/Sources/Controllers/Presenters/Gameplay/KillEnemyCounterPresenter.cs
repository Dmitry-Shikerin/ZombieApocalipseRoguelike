using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.PresentationsInterfaces.UI.Sliders;
using Sources.PresentationsInterfaces.Views.Gameplay;
using Sources.Utils.Extentions;

namespace Sources.Controllers.Presenters.Gameplay
{
    public class KillEnemyCounterPresenter : PresenterBase
    {
        private readonly KillEnemyCounter _killEnemyCounter;
        private readonly IEnemySpawner _enemySpawner;
        private readonly IKillEnemyCounterView _killEnemyCounterView;

        public KillEnemyCounterPresenter(
            KillEnemyCounter killEnemyCounter,
            IEnemySpawner enemySpawner,
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
            HideSeparators();
            SetSeparators();
            _killEnemyCounter.KillZombiesCountChanged += OnKillZombieCountChanged;
        }

        public override void Disable()
        {
            _killEnemyCounter.KillZombiesCountChanged -= OnKillZombieCountChanged;
        }

        private void OnKillZombieCountChanged()
        {
            float percent = _killEnemyCounter.KillZombies.IntToPercent(_enemySpawner.SumEnemies);
            float fillAmount = percent.FloatPercentToUnitPercent();
            _killEnemyCounterView.KillEnemyBar.SetFillAmount(fillAmount);
        }

        private void SetSeparators()
        {
            for (int i = 0; i < _enemySpawner.EnemyInWave.Count; i++)
            {
                _killEnemyCounterView.WaveSeparators[i].Show();
                float percent = _enemySpawner.SumEnemiesInWave[i].IntToPercent(_enemySpawner.SumEnemies);
                float fillAmount = percent.FloatPercentToUnitPercent();
                _killEnemyCounterView.WaveSeparators[i].SetValue(fillAmount);
            }
        }

        private void HideSeparators()
        {
            foreach (ISliderView waveSeparator in _killEnemyCounterView.WaveSeparators)
                waveSeparator.Hide();
        }
    }
}