using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class GameplayButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands =
            new Dictionary<ButtonCommandId, IButtonCommand>();
        
        public GameplayButtonCommandHandler(
            ShowFormCommand showFormCommand,
            CompleteTutorialCommand completeTutorialCommand,
            LoadMainMenuSceneCommand loadMainMenuSceneCommand,
            UnPauseButtonCommand unPauseButtonCommand,
            HideFormCommand hideFormCommand,
            SetAllMapCameraFollowCommand setAllMapCameraFollowCommand,
            SetCharacterCameraFollowCommand setCharacterCameraFollowCommand)
        {
            _commands[showFormCommand.Id] = showFormCommand;
            _commands[completeTutorialCommand.Id] = completeTutorialCommand;
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[unPauseButtonCommand.Id] = unPauseButtonCommand;
            _commands[hideFormCommand.Id] = hideFormCommand;
            _commands[setAllMapCameraFollowCommand.Id] = setAllMapCameraFollowCommand;
            _commands[setCharacterCameraFollowCommand.Id] = setCharacterCameraFollowCommand;
        }

        public void Handle(UiButton uiButton, ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle(uiButton);

        }
    }
}