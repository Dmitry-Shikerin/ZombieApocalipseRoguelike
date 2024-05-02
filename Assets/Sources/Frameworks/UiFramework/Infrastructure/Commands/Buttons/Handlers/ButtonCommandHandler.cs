using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class ButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands =
            new Dictionary<ButtonCommandId, IButtonCommand>();

        public ButtonCommandHandler(
            ShowFormCommand showFormCommand,
            CompleteTutorialCommand completeTutorialCommand,
            LoadMainMenuSceneCommand loadMainMenuSceneCommand,
            LoadGameCommand loadGameCommand,
            NewGameCommand newGameCommand,
            ShowLeaderboardCommand showLeaderBoardCommand,
            EnableLoadGameButtonCommand enableLoadGameButtonCommand)
        {
            _commands[showFormCommand.Id] = showFormCommand;
            _commands[completeTutorialCommand.Id] = completeTutorialCommand;
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[loadGameCommand.Id] = loadGameCommand;
            _commands[newGameCommand.Id] = newGameCommand;
            _commands[showLeaderBoardCommand.Id] = showLeaderBoardCommand;
            _commands[enableLoadGameButtonCommand.Id] = enableLoadGameButtonCommand;
        }

        public void Handle(UiUiUiUiButton uiUiUiUiButton, ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle(uiUiUiUiButton);
        }
    }
}