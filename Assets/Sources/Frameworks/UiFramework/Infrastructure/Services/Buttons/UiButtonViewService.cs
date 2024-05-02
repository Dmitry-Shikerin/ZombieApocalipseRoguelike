using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons.Handlers;
using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Services.Buttons
{
    public class UiButtonViewService
    {
        private readonly IButtonCommandHandler _commandHandler;

        public UiButtonViewService(IButtonCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public void Handle(IEnumerable<ButtonCommandId> commandIds, UiUiUiUiButton uiUiUiUiButton)
        {
            foreach (ButtonCommandId commandId in commandIds)
            {
                _commandHandler.Handle(uiUiUiUiButton, commandId);
            }
        }
    }
}