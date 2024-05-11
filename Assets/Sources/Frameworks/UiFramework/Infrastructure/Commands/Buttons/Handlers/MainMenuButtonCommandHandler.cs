using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class MainMenuButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands =
            new Dictionary<ButtonCommandId, IButtonCommand>();
        
        public MainMenuButtonCommandHandler(
            ShowFormCommand showFormCommand,
            LoadGameCommand loadGameCommand,
            NewGameCommand newGameCommand,
            ShowLeaderboardCommand showLeaderBoardCommand,
            EnableLoadGameButtonCommand enableLoadGameButtonCommand,
            ClearSavesButtonCommand clearSavesButtonCommand)
        {
            _commands[showFormCommand.Id] = showFormCommand;
            _commands[loadGameCommand.Id] = loadGameCommand;
            _commands[newGameCommand.Id] = newGameCommand;
            _commands[showLeaderBoardCommand.Id] = showLeaderBoardCommand;
            _commands[enableLoadGameButtonCommand.Id] = enableLoadGameButtonCommand;
            _commands[clearSavesButtonCommand.Id] = clearSavesButtonCommand;
        }
        
        public void Handle(UiButton uiButton, ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle(uiButton);
        }
    }
}