using System;
using Sources.DomainInterfaces.Models.Upgrades;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.Views.Upgrades;
using UnityEngine;

namespace Sources.Controllers.Presenters.Upgrades
{
    public class UpgradeUiPresenter : PresenterBase
    {
        private readonly IUpgrader _upgrader;
        private readonly IUpgradeUi _upgradeUi;
        private readonly IUpgradeConfigCollectionService _upgradeConfigCollectionService;

        public UpgradeUiPresenter(
            IUpgrader upgrader, 
            IUpgradeUi upgradeUi,
            IUpgradeConfigCollectionService upgradeConfigCollectionService)
        {
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            _upgradeUi = upgradeUi ?? throw new ArgumentNullException(nameof(upgradeUi));
            _upgradeConfigCollectionService = upgradeConfigCollectionService ?? 
                                       throw new ArgumentNullException(nameof(upgradeConfigCollectionService));
        }

        public override void Enable()
        {
            AbilityImageChanged();
            OnLevelChanged();
            _upgrader.LevelChanged += OnLevelChanged;
        }

        public override void Disable() =>
            _upgrader.LevelChanged -= OnLevelChanged;

        private void OnLevelChanged()
        {
            UpdatePrice();
            UpdateImages();
            AbilityImageChanged();
        }

        private void UpdatePrice()
        {
            if(_upgrader.CurrentLevel == _upgrader.MaxLevel)
            {
                _upgradeUi.SetPriceNextUpgrade("Max");
                return;
            }
            
            string price = _upgrader.MoneyPerUpgrades[_upgrader.CurrentLevel].ToString();
            _upgradeUi.SetPriceNextUpgrade(price);
        }

        private void UpdateImages()
        {
            foreach (IImageView imageView in _upgradeUi.LevelImageViews)
                imageView.HideImage();

            for (int i = 0; i < _upgrader.CurrentLevel; i++)
                _upgradeUi.LevelImageViews[i].ShowImage();
        }

        private void AbilityImageChanged()
        {
            Sprite sprite = _upgradeConfigCollectionService.GetConfig(_upgrader.Id).Sprite;
            _upgradeUi.AbilityImageView.SetSprite(sprite);
        }
    }
}