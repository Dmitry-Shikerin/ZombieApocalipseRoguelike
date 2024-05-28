using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;

namespace Sources.Frameworks.UiFramework.Services.Views
{
    public interface IUiViewService
    {
        void Handle(IEnumerable<FormCommandId> commandIds);
    }
}