﻿using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons.Collectors
{
    public class ButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands =
            new Dictionary<ButtonCommandId, IButtonCommand>();

        public ButtonCommandHandler(
            ShowFormCommand showFormCommand,
            CompleteTutorialCommand completeTutorialCommand,
            LoadMainMenuSceneCommand loadMainMenuSceneCommand,
            LoadGameCommand loadGameCommand,
            NewGameCommand newGameCommand,
            ShowLeaderboardCommand showLeaderBoardCommand)
        {
            _commands[showFormCommand.Id] = showFormCommand;
            _commands[completeTutorialCommand.Id] = completeTutorialCommand;
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[loadGameCommand.Id] = loadGameCommand;
            _commands[newGameCommand.Id] = newGameCommand;
            _commands[showLeaderBoardCommand.Id] = showLeaderBoardCommand;
        }

        public void Handle(UiButton uiButton, ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle(uiButton);
        }
    }
}