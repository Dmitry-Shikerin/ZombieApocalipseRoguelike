﻿using System;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.PlayerAccounts;
using Sources.InfrastructureInterfaces.Services.YandexSDKServices;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons
{
    public class ShowLeaderboardCommand : IButtonCommand
    {
        private readonly IPlayerAccountAuthorizeService _playerAccountAuthorizeService;
        private readonly ILeaderboardInitializeService _leaderboardInitializeService;
        private readonly IFormService _formService;

        public ShowLeaderboardCommand(
            IPlayerAccountAuthorizeService playerAccountAuthorizeService,
            ILeaderboardInitializeService leaderboardInitializeService,
            IFormService formService)
        {
            _playerAccountAuthorizeService = playerAccountAuthorizeService ?? 
                                             throw new ArgumentNullException(nameof(playerAccountAuthorizeService));
            _leaderboardInitializeService = leaderboardInitializeService ?? 
                                            throw new ArgumentNullException(nameof(leaderboardInitializeService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ButtonCommandId Id => ButtonCommandId.Leaderboard;
        
        public void Handle(UiButton uiButton)
        {
            if (_playerAccountAuthorizeService.IsAuthorized() == false)
            {
                _formService.ShowOneForm(FormId.Authorization);

                return;
            }

            _leaderboardInitializeService.Fill();
            _formService.ShowOneForm(FormId.Leaderboard);
        }
    }
}