using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Controllers.Upgrades;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.Views.Upgrades;
using TMPro;
using UnityEngine;

namespace Sources.Presentations.Views.Upgrades
{
    public class UpgradeUi : PresentableView<UpgradeUiPresenter>, IUpgradeUi
    {
        [Required] [SerializeField] private List<ImageView> _imageViews;
        [Required] [SerializeField] private TextMeshProUGUI _priceNextUpgrade;

        public IReadOnlyList<IImageView> ImageViews => _imageViews;

        public void SetPriceNextUpgrade(string text) =>
            _priceNextUpgrade.text = text;
    }
}