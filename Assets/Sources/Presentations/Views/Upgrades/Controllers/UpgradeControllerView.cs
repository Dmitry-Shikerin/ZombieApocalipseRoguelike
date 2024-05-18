using System.Collections.Generic;
using Sources.Controllers.Presenters.Upgrades.Controllers;
using Sources.PresentationsInterfaces.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades.Controllers;
using UnityEngine;

namespace Sources.Presentations.Views.Upgrades.Controllers
{
    public class UpgradeControllerView : PresentableView<UpgradeControllerPresenter>, IUpgradeControllerView
    {
        [SerializeField] private List<UpgradeUi> _upgradeUis;
        [SerializeField] private List<UpgradeView> _upgradeViews;
        [SerializeField] private List<UpgradeDescriptionView> _upgradeUisDescriptionViews;

        public IReadOnlyList<UpgradeUi> UpgradeUis => _upgradeUis;
        public IReadOnlyList<UpgradeView> UpgradeViews => _upgradeViews;
        public IReadOnlyList<UpgradeDescriptionView> UpgradeDescriptionViews => _upgradeUisDescriptionViews;
    }
}