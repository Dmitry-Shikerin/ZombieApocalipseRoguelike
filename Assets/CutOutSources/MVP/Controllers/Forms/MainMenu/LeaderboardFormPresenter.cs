﻿using System;
using Sources.Controllers.Presenters;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Common.Forms.MainMenu
{
    public class LeaderboardFormPresenter : PresenterBase
    {
        private readonly ILeaderBoardFormView _view;
        private readonly IMVPFormService _imvpFormService;

        public LeaderboardFormPresenter(
            ILeaderBoardFormView view, 
            IMVPFormService imvpFormService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public override void Enable()
        {
            _view.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);
        }

        public override void Disable()
        {
            _view.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);
        }

        private void ShowMainMenuHudForm()
        {
            _imvpFormService.Show<MainMenuHudFormView>();
        }
    }
}