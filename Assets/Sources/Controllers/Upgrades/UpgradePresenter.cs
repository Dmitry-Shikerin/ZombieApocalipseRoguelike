using System;
using Sources.Controllers.Common;
using Sources.Domain.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Controllers.Upgrades
{
    public class UpgradePresenter : PresenterBase
    {
        private readonly Upgrader _upgrader;
        private readonly IUpgradeView _upgradeView;

        public UpgradePresenter(Upgrader upgrader, IUpgradeView upgradeView)
        {
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            _upgradeView = upgradeView ?? throw new ArgumentNullException(nameof(upgradeView));
        }

        public override void Enable() =>
            _upgradeView.UpgradeButton.AddClickListener(OnUpgrade);

        public override void Disable() =>
            _upgradeView.UpgradeButton.AddClickListener(OnUpgrade);

        private void OnUpgrade() =>
            _upgrader.Upgrade();
    }
}