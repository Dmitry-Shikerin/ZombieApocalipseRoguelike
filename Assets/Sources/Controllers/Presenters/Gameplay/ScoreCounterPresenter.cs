using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Models.Characters;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.YandexSDKServices;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Controllers.Presenters.Gameplay
{
    public class ScoreCounterPresenter : PresenterBase
    {
        private readonly ScoreCounter _scoreCounter;
        private readonly IKillEnemyCounter _killEnemyCounter;
        private readonly ILevel _level;
        private readonly ICharacterHealth _characterHealth;
        private readonly IScoreCounterView _view;
        private readonly ILeaderBoardScoreSetter _leaderBoardScoreSetter;
        private readonly ILoadService _loadService;

        public ScoreCounterPresenter(
            ScoreCounter scoreCounter,
            IKillEnemyCounter killEnemyCounter,
            ILevel level,
            ICharacterHealth characterHealth,
            IScoreCounterView view,
            ILeaderBoardScoreSetter leaderBoardScoreSetter,
            ILoadService loadService)
        {
            _scoreCounter = scoreCounter ?? throw new ArgumentNullException(nameof(scoreCounter));
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _level = level ?? throw new ArgumentNullException(nameof(level));
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _leaderBoardScoreSetter = leaderBoardScoreSetter ?? 
                                      throw new ArgumentNullException(nameof(leaderBoardScoreSetter));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public override void Enable()
        {
            OnKillZombiesCountChanged();
            _killEnemyCounter.KillZombiesCountChanged += OnKillZombiesCountChanged;
            _level.Completed += OnLevelCompleted;
            _characterHealth.CharacterDie += OnCharacterDie;
        }

        public override void Disable()
        {
            _killEnemyCounter.KillZombiesCountChanged -= OnKillZombiesCountChanged;
            _level.Completed -= OnLevelCompleted;
            _characterHealth.CharacterDie -= OnCharacterDie;
        }

        private void OnKillZombiesCountChanged()
        {
            SetScore(1);
        }

        private void OnCharacterDie()
        {
            SetScore(1);
            SaveScore();
        }

        private void OnLevelCompleted()
        {
            SetScore(2);
            SaveScore();
        }

        private void SetScore(int multiplier)
        {
            int score = _killEnemyCounter.KillZombies * multiplier;

            _scoreCounter.SetCurrentScore(score);

            foreach (IUiText text in _view.Texts)
                text.SetText(score.ToString());
        }

        private void SaveScore()
        {
            _scoreCounter.AddTotalScore();
            _leaderBoardScoreSetter.SetPlayerScore(_scoreCounter.TotalScore);
            _loadService.Save(ModelId.ScoreCounter);
        }
    }
}