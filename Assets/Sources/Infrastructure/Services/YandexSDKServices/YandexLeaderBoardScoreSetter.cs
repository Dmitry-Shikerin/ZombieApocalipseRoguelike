using Agava.WebUtility;
using Agava.YandexGames;
using Sources.Domain.Constants;
using Sources.InfrastructureInterfaces.Services.YandexSDKServices;

namespace Sources.Infrastructure.Services.YandexSDKServices
{
    public class YandexLeaderBoardScoreSetter : ILeaderBoardScoreSetter
    {
        public void SetPlayerScore(int score)
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return;

            if (PlayerAccount.IsAuthorized == false)
                return;
            
            Leaderboard.GetPlayerEntry(LeaderBoardName.Leaderboard, result =>
            {
                if (result.score < score)
                    Leaderboard.SetScore(LeaderBoardName.Leaderboard, score);
            });
        }
    }
}