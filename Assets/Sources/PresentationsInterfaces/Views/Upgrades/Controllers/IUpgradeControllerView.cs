using System.Collections.Generic;
using Sources.Presentations.Views.Upgrades;

namespace Sources.PresentationsInterfaces.Views.Upgrades.Controllers
{
    public interface IUpgradeControllerView
    {
        IReadOnlyList<UpgradeUi> UpgradeUis { get; }
    }
}