using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Infrastructure.Commands.Forms.Collectors;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Frameworks.UiFramework.Infrastructure.Services.Forms
{
    public class UiViewService
    {
        private readonly ViewCommandHandler _viewCommandHandler;

        public UiViewService(ViewCommandHandler viewCommandHandler)
        {
            _viewCommandHandler = viewCommandHandler;
        }

        public void Handle(IEnumerable<FormCommandId> commandIds)
        {
            foreach (FormCommandId commandId in commandIds)
            {
                _viewCommandHandler.Handle(commandId);
            }
        }
    }
}