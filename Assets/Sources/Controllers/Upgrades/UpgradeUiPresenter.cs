using System;
using Sources.Controllers.Common;
using Sources.DomainInterfaces.Upgrades;
using Sources.Infrastructure.Services.Icons;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.Views.Upgrades;
using UnityEngine;

namespace Sources.Controllers.Upgrades
{
    public class UpgradeUiPresenter : PresenterBase
    {
        private readonly IUpgrader _upgrader;
        private readonly IUpgradeUi _upgradeUi;
        private readonly ISpriteCollectionService _spriteCollectionService;

        public UpgradeUiPresenter(
            IUpgrader upgrader, 
            IUpgradeUi upgradeUi,
            ISpriteCollectionService spriteCollectionService)
        {
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            _upgradeUi = upgradeUi ?? throw new ArgumentNullException(nameof(upgradeUi));
            _spriteCollectionService = spriteCollectionService ?? 
                                       throw new ArgumentNullException(nameof(spriteCollectionService));
        }

        public override void Enable()
        {
            AbilityImageChanged();
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
            Sprite sprite = _spriteCollectionService.GetIcon(_upgrader.Id);
            _upgradeUi.AbilityImageView.SetSprite(sprite);
        }
    }
}