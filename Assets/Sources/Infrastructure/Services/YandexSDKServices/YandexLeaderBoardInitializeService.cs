using System;
using System.Collections.Generic;
using Agava.WebUtility;
using Agava.YandexGames;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.YandexSDK;
using Sources.Infrastructure.Factories.Views.YandexSDK;
using Sources.InfrastructureInterfaces.Services.YandexSDKServices;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.YandexSDK;

namespace Sources.Infrastructure.Services.YandexSDKServices
{
    public class YandexLeaderBoardInitializeService : ILeaderBoardInitializeService
    {
        private readonly LeaderBoardElementViewFactory _leaderBoardElementViewFactory;
        private IReadOnlyList<LeaderBoardElementView> _leaderBoardElementViews;
        
        public YandexLeaderBoardInitializeService(MainMenuHud mainMenuHud,
            LeaderBoardElementViewFactory leaderBoardElementViewFactory)
        {
            if (mainMenuHud == null)
                throw new ArgumentNullException(nameof(mainMenuHud));

            _leaderBoardElementViews = mainMenuHud.LeaderBoardElementViews;
            
            _leaderBoardElementViewFactory = leaderBoardElementViewFactory ??
                                             throw new ArgumentNullException(nameof(leaderBoardElementViewFactory));
        }
        
        public void Fill()
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return;

            if (PlayerAccount.IsAuthorized == false)
                return;
            
            Leaderboard.GetEntries(LeaderBoardName.Leaderboard, result =>
            {
                var count = result.entries.Length < _leaderBoardElementViews.Count
                    ? result.entries.Length
                    : _leaderBoardElementViews.Count;
                
                for (var i = 0; i < count; i++)
                {
                    var rank = result.entries[i].rank;
                    var score = result.entries[i].score;
                    var name = result.entries[i].player.publicName;

                    if (string.IsNullOrEmpty(name))
                        name = YandexGamesSdk.Environment.i18n.lang switch
                        {
                            LocalizationConstant.English => Anonymous.English,
                            LocalizationConstant.Turkish => Anonymous.Turkish,
                            LocalizationConstant.Russian => Anonymous.Russian,
                            _ => Anonymous.English
                        };

                    _leaderBoardElementViewFactory.Create(
                        new LeaderBoardPlayer(rank, name, score),
                        _leaderBoardElementViews[i]);
                }

            });
        }
    }
}