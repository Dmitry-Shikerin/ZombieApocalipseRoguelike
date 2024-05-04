using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Upgrades;
using Sources.Controllers.Upgrades;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.Views.Upgrades;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.Views.Upgrades
{
    public class UpgradeUi : PresentableView<UpgradeUiPresenter>, IUpgradeUi
    {
        [Required] [SerializeField] private List<ImageView> _imageViews;
        [Required] [SerializeField] private TextMeshProUGUI _priceNextUpgrade;
        [Required] [SerializeField] private ImageView _abilityImageView;

        public IReadOnlyList<IImageView> LevelImageViews => _imageViews;
        public IImageView AbilityImageView => _abilityImageView;

        public void SetPriceNextUpgrade(string text) =>
            _priceNextUpgrade.text = text;
    }
}