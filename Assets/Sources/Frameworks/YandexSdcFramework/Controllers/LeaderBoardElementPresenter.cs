﻿using System;
using Sources.Controllers.Presenters;
using Sources.Frameworks.YandexSdcFramework.Domain;
using Sources.Frameworks.YandexSdcFramework.PresentationsInterfaces.Views;

namespace Sources.Frameworks.YandexSdcFramework.Controllers
{
    public class LeaderBoardElementPresenter : PresenterBase
    {
        private readonly LeaderBoardPlayer _leaderBoardPlayer;
        private readonly ILeaderBoardElementView _leaderboardElementView;

        public LeaderBoardElementPresenter(
            LeaderBoardPlayer leaderBoardPlayer, 
            ILeaderBoardElementView leaderboardElementView)
        {
            _leaderBoardPlayer = leaderBoardPlayer ?? throw new ArgumentNullException(nameof(leaderBoardPlayer));
            _leaderboardElementView = leaderboardElementView ??
                                      throw new ArgumentNullException(nameof(leaderboardElementView));
        }

        public override void Enable()
        {
            _leaderboardElementView.SetName(_leaderBoardPlayer.Name);
            _leaderboardElementView.SetRank(_leaderBoardPlayer.Rank.ToString());
            _leaderboardElementView.SetScore(_leaderBoardPlayer.Score.ToString());
        }
    }
}