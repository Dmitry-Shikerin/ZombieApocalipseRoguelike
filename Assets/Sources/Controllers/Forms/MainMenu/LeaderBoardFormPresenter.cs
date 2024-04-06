using System;
using JetBrains.Annotations;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Forms.MainMenu
{
    public class LeaderBoardFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly ILeaderBoardFormView _leaderBoardFormView;

        public LeaderBoardFormPresenter(IFormService formService, ILeaderBoardFormView leaderBoardFormView)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _leaderBoardFormView = leaderBoardFormView ??
                                   throw new ArgumentNullException(nameof(leaderBoardFormView));
        }

        public override void Enable() =>
            _leaderBoardFormView.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);

        public override void Disable() =>
            _leaderBoardFormView.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);

        private void ShowMainMenuHudForm() =>
            _formService.Show<MainMenuHudFormView>();
    }
}