using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;
using Sources.Frameworks.UiFramework.PresentationsInterfaces.Buttons;

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
            SetCharacterCameraFollowCommand setCharacterCameraFollowCommand,
            ShowRewardedAdvertisingButtonCommand showRewardedAdvertisingButtonCommand,
            ClearSavesButtonCommand clearSavesButtonCommand)
        {
            _commands[showFormCommand.Id] = showFormCommand;
            _commands[completeTutorialCommand.Id] = completeTutorialCommand;
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[unPauseButtonCommand.Id] = unPauseButtonCommand;
            _commands[hideFormCommand.Id] = hideFormCommand;
            _commands[setAllMapCameraFollowCommand.Id] = setAllMapCameraFollowCommand;
            _commands[setCharacterCameraFollowCommand.Id] = setCharacterCameraFollowCommand;
            _commands[showRewardedAdvertisingButtonCommand.Id] = showRewardedAdvertisingButtonCommand;
            _commands[clearSavesButtonCommand.Id] = clearSavesButtonCommand;
        }

        public void Handle(IUiButton uiButton, ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle(uiButton);

        }
    }
}