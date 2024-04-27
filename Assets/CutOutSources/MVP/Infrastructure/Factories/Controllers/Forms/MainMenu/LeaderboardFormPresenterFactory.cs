using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class LeaderboardFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;

        public LeaderboardFormPresenterFactory(IMVPFormService imvpFormService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public LeaderboardFormPresenter Create(ILeaderBoardFormView view)
        {
            return new LeaderboardFormPresenter(view, _imvpFormService);
        }
    }
}