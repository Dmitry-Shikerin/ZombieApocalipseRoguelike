using System.Collections.Generic;
using Sources.Controllers.Upgrades.Controllers;
using Sources.PresentationsInterfaces.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades.Controllers;
using UnityEngine;

namespace Sources.Presentations.Views.Upgrades.Controllers
{
    public class UpgradeControllerView : PresentableView<UpgradeControllerPresenter>, IUpgradeControllerView
    {
        [SerializeField] private List<UpgradeUi> _upgradeUis;
        
        public IReadOnlyList<IUpgradeUi> UpgradeUis => _upgradeUis;
    }
}