using System;
using Sources.Frameworks.YandexSdcFramework.Controllers;
using Sources.Frameworks.YandexSdcFramework.Domain;
using Sources.Frameworks.YandexSdcFramework.Infrastructure.Factories.Controllers;
using Sources.Frameworks.YandexSdcFramework.Presentations.Views;
using Sources.Frameworks.YandexSdcFramework.PresentationsInterfaces.Views;

namespace Sources.Frameworks.YandexSdcFramework.Infrastructure.Factories.Views
{
    public class LeaderBoardElementViewFactory
    {
        private readonly LeaderBoardElementPresenterFactory _leaderBoardElementPresenterFactory;

        public LeaderBoardElementViewFactory(LeaderBoardElementPresenterFactory leaderBoardElementPresenterFactory)
        {
            _leaderBoardElementPresenterFactory = leaderBoardElementPresenterFactory ??
                                                  throw new ArgumentNullException(nameof(leaderBoardElementPresenterFactory));
        }

        public ILeaderBoardElementView Create(
            LeaderBoardPlayer leaderBoardPlayer,
            LeaderBoardElementView leaderBoardElementView)
        {
            if (leaderBoardPlayer == null)
                throw new ArgumentNullException(nameof(leaderBoardPlayer));

            if (leaderBoardElementView == null)
                throw new ArgumentNullException(nameof(leaderBoardElementView));

            LeaderBoardElementPresenter leaderBoardElementPresenter =
                _leaderBoardElementPresenterFactory.Create(leaderBoardPlayer, leaderBoardElementView);

            leaderBoardElementView.Construct(leaderBoardElementPresenter);

            return leaderBoardElementView;
        }
    }
}