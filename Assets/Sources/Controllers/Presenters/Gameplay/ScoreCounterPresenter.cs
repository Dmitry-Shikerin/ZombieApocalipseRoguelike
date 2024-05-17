using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Controllers.Presenters.Gameplay
{
    public class ScoreCounterPresenter : PresenterBase
    {
        private readonly ScoreCounter _scoreCounter;
        private readonly IKillEnemyCounter _killEnemyCounter;
        private readonly ILevel _level;
        private readonly IScoreCounterView _view;

        public ScoreCounterPresenter(
            ScoreCounter scoreCounter,
            IKillEnemyCounter killEnemyCounter,
            ILevel level,
            IScoreCounterView view)
        {
            _scoreCounter = scoreCounter ?? throw new ArgumentNullException(nameof(scoreCounter));
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _level = level ?? throw new ArgumentNullException(nameof(level));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            OnKillZombiesCountChanged();
            _killEnemyCounter.KillZombiesCountChanged += OnKillZombiesCountChanged;
            _level.Completed += OnLevelCompleted;
        }

        public override void Disable()
        {
            _killEnemyCounter.KillZombiesCountChanged -= OnKillZombiesCountChanged;
            _level.Completed -= OnLevelCompleted;
        }

        private void OnKillZombiesCountChanged()
        {
            SetScore(1);
        }

        private void OnLevelCompleted()
        {
            SetScore(2);
        }

        private void SetScore(int multiplier)
        {
            int score = _killEnemyCounter.KillZombies * multiplier;

            _scoreCounter.SetScore(score);

            foreach (IUiText text in _view.Texts)
                text.SetText(score.ToString());
        }
    }
}