using System;
using Sources.Controllers.Common;
using Sources.DomainInterfaces.Upgrades;
using Sources.PresentationsInterfaces.UI.Images;
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

        private void OnLevelChanged()
        {
            Debug.Log($"Upgrade: {_upgrader.CurrentLevel}");
            UpdatePrice();
            UpdateImages();
        }

        private void UpdatePrice()
        {
            if(_upgrader.CurrentLevel == _upgrader.MaxLevel)
            {
                _upgradeUi.SetPriceNextUpgrade("Max");
                return;
            }
            
            string price = _upgrader.MoneyPerUpgrades[_upgrader.CurrentLevel + 1].ToString();
            _upgradeUi.SetPriceNextUpgrade(price);
        }

        private void UpdateImages()
        {
            foreach (IImageView imageView in _upgradeUi.ImageViews)
                imageView.HideImage();

            for (int i = 0; i < _upgrader.CurrentLevel; i++)
                _upgradeUi.ImageViews[i].ShowImage();
        }
    }
}