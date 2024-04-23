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
        private readonly IViewFormService _viewFormService;
        private readonly ILeaderBoardFormView _leaderBoardFormView;

        public LeaderBoardFormPresenter(IViewFormService viewFormService, ILeaderBoardFormView leaderBoardFormView)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
            _leaderBoardFormView = leaderBoardFormView ??
                                   throw new ArgumentNullException(nameof(leaderBoardFormView));
        }

        public override void Enable() =>
            _leaderBoardFormView.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);

        public override void Disable() =>
            _leaderBoardFormView.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);

        private void ShowMainMenuHudForm() =>
            _viewFormService.Show<MainMenuHudFormView>();
    }
}