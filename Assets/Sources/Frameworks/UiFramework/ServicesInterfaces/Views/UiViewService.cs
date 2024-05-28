using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Views.Handlers;
using Sources.Frameworks.UiFramework.Services.Views;

namespace Sources.Frameworks.UiFramework.ServicesInterfaces.Views
{
    public class UiViewService : IUiViewService
    {
        private readonly IUiViewCommandHandler _uiViewCommandHandler;

        public UiViewService(IUiViewCommandHandler uiViewCommandHandler)
        {
            _uiViewCommandHandler = uiViewCommandHandler;
        }

        public void Handle(IEnumerable<FormCommandId> commandIds)
        {
            foreach (FormCommandId commandId in commandIds)
                _uiViewCommandHandler.Handle(commandId);
        }
    }
}