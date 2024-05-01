using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons.Collectors;
using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Services.Buttons
{
    public class UiButtonViewService
    {
        private readonly ButtonCommandHandler _commandHandler;

        public UiButtonViewService(ButtonCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public void Handle(IEnumerable<ButtonCommandId> commandIds, UiButton uiButton)
        {
            foreach (ButtonCommandId commandId in commandIds)
            {
                _commandHandler.Handle(uiButton, commandId);
            }
        }
    }
}