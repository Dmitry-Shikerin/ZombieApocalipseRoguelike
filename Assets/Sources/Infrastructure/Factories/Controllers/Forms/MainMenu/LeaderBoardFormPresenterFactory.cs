using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Forms.MainMenu
{
    public class LeaderBoardFormPresenterFactory
    {
        private readonly IFormService _formService;

        public LeaderBoardFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public LeaderBoardFormPresenter Create(ILeaderBoardFormView leaderBoardFormView)
        {
            if (leaderBoardFormView == null)
                throw new ArgumentNullException(nameof(leaderBoardFormView));

            return new LeaderBoardFormPresenter(_formService, leaderBoardFormView);
        }
    }
}