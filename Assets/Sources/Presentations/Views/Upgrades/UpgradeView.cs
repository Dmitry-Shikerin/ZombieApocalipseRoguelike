using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Upgrades;
using Sources.Presentations.UI.Buttons;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Upgrades;
using UnityEngine;

namespace Sources.Presentations.Views.Upgrades
{
    public class UpgradeView : PresentableView<UpgradePresenter>, IUpgradeView
    {
        [Required] [SerializeField] private ButtonView _upgradeButton;

        public IButtonView UpgradeButton => _upgradeButton;
    }
}