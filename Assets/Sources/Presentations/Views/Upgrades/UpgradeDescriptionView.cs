using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Upgrades;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Upgrades;
using UnityEngine;

namespace Sources.Presentations.Views.Upgrades
{
    public class UpgradeDescriptionView : PresentableView<UpgradeDescriptionPresenter>, IUpgradeDescriptionView
    {
        [Required] [SerializeField] private UiText _descriptionText;

        public IUiText Text => _descriptionText;
    }
}