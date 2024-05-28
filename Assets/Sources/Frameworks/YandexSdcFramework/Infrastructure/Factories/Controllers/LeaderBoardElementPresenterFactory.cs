using System;
using Sources.Frameworks.YandexSdcFramework.Controllers;
using Sources.Frameworks.YandexSdcFramework.Domain;
using Sources.Frameworks.YandexSdcFramework.PresentationsInterfaces.Views;

namespace Sources.Frameworks.YandexSdcFramework.Infrastructure.Factories.Controllers
{
    public class LeaderBoardElementPresenterFactory
    {
        public LeaderBoardElementPresenter Create(
            LeaderBoardPlayer leaderBoardPlayer,
            ILeaderBoardElementView leaderBoardElementView)
        {
            if (leaderBoardPlayer == null)
                throw new ArgumentNullException(nameof(leaderBoardPlayer));
            if (leaderBoardElementView == null)
                throw new ArgumentNullException(nameof(leaderBoardElementView));

            return new LeaderBoardElementPresenter(leaderBoardPlayer, leaderBoardElementView);
        }
    }
}