using System;
using Sources.Controllers.Presenters.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.DomainInterfaces.Models.Characters;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.YandexSDKServices;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Gameplay
{
    public class ScoreCounterPresenterFactory
    {
        private readonly ILeaderBoardScoreSetter _leaderBoardScoreSetter;
        private readonly ILoadService _loadService;

        public ScoreCounterPresenterFactory(
            ILeaderBoardScoreSetter leaderBoardScoreSetter,
            ILoadService loadService)
        {
            _leaderBoardScoreSetter = leaderBoardScoreSetter ?? 
                                      throw new ArgumentNullException(nameof(leaderBoardScoreSetter));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public ScoreCounterPresenter Create(
            ScoreCounter scoreCounter, 
            IKillEnemyCounter killEnemyCounter, 
            ILevel level, 
            ICharacterHealth characterHealth,
            IScoreCounterView view)
        {
            return new ScoreCounterPresenter(
                scoreCounter, 
                killEnemyCounter, 
                level,
                characterHealth,
                view,
                _leaderBoardScoreSetter,
                _loadService);
        }
    }
}