using Sirenix.OdinInspector;
using Sources.Controllers.Players;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Players;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.Views.Players
{
    public class PlayerWalletView : PresentableView<PlayerWalletPresenter>, IPlayerWalletView
    {
        [FormerlySerializedAs("coinsUiUiText")] [FormerlySerializedAs("_coinsTextView")] [Required] [SerializeField] private UiText coinsUiText;

        public IUiText CoinsUiText => coinsUiText;
    }
}