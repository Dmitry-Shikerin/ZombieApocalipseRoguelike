using System;
using Sources.Controllers.Common;
using Sources.DomainInterfaces.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;
using UnityEngine;

namespace Sources.Controllers.Upgrades
{
    public class UpgradeUiPresenter : PresenterBase
    {
        private readonly IUpgrader _upgrader;
        private readonly IUpgradeUi _upgradeUi;

        public UpgradeUiPresenter(IUpgrader upgrader, IUpgradeUi upgradeUi)
        {
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            _upgradeUi = upgradeUi ?? throw new ArgumentNullException(nameof(upgradeUi));
        }

        public override void Enable()
        {
            OnLevelChanged();
            _upgrader.LevelChanged += OnLevelChanged;
        }

        public override void Disable()
        {
            _upgrader.LevelChanged -= OnLevelChanged;
        }

        //TODO можно заменить на сервис
        private void OnLevelChanged()
        {
            Debug.Log($"Upgrade: {_upgrader.CurrentLevel}");
        }
    }
}