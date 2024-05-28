﻿using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Views;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Views.Handlers;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Forms.Handlers
{
    public class GameplayUiViewCommandHandler : IUiViewCommandHandler
    {
        private readonly Dictionary<FormCommandId, IViewCommand> _commands = 
            new Dictionary<FormCommandId, IViewCommand>();
        
        public GameplayUiViewCommandHandler(
            PauseCommand pauseCommand,
            UnPauseCommand unPauseCommand,
            SaveVolumeCommand saveVolumeCommand,
            ClearSavesCommand clearSavesCommand,
            SetAllMapCameraFollowViewCommand setAllMapCameraFollowViewCommand,
            SetCharacterCameraFollowViewCommand setCharacterCameraFollowUiViewCommand)
        {
            _commands[pauseCommand.Id] = pauseCommand;
            _commands[unPauseCommand.Id] = unPauseCommand;
            _commands[saveVolumeCommand.Id] = saveVolumeCommand;
            _commands[clearSavesCommand.Id] = clearSavesCommand;
            _commands[setAllMapCameraFollowViewCommand.Id] = setAllMapCameraFollowViewCommand;
            _commands[setCharacterCameraFollowUiViewCommand.Id] = setCharacterCameraFollowUiViewCommand;
        }

        public void Handle(FormCommandId formCommandId)
        {
            if(_commands.ContainsKey(formCommandId) == false)
                throw new KeyNotFoundException(nameof(formCommandId));
            
            _commands[formCommandId].Handle();
        }
    }
}