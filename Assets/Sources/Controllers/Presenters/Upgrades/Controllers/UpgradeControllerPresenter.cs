using System;
using Sources.Controllers.Common;
using Sources.Domain.Upgrades.Controllers;
using Sources.PresentationsInterfaces.Views.Upgrades.Controllers;

namespace Sources.Controllers.Upgrades.Controllers
{
    public class UpgradeControllerPresenter : PresenterBase
    {
        private readonly UpgradeController _upgradeController;
        private readonly IUpgradeControllerView _upgradeControllerView;

        public UpgradeControllerPresenter(
            UpgradeController upgradeController, 
            IUpgradeControllerView upgradeControllerView)
        {
            _upgradeController = upgradeController ?? throw new ArgumentNullException(nameof(upgradeController));
            _upgradeControllerView = upgradeControllerView ?? throw new ArgumentNullException(nameof(upgradeControllerView));
        }

        public override void Enable()
        {
        }

        public override void Disable()
        {
        }
    }
}