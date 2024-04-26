using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class LeaderboardFormPresenterFactory
    {
        private readonly IFormService _formService;

        public LeaderboardFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public LeaderboardFormPresenter Create(ILeaderBoardFormView view)
        {
            return new LeaderboardFormPresenter(view, _formService);
        }
    }
}