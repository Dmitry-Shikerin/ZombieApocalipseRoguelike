using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Infrastructure.Commands.Forms.Handlers;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Frameworks.UiFramework.Infrastructure.Services.Forms
{
    public class UiViewService
    {
        private readonly UiViewCommandHandler _uiViewCommandHandler;

        public UiViewService(UiViewCommandHandler uiViewCommandHandler)
        {
            _uiViewCommandHandler = uiViewCommandHandler;
        }

        public void Handle(IEnumerable<FormCommandId> commandIds)
        {
            foreach (FormCommandId commandId in commandIds)
            {
                _uiViewCommandHandler.Handle(commandId);
            }
        }
    }
}