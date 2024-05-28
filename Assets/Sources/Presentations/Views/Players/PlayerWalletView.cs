using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Players;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Presentations.Views.Players
{
    public class PlayerWalletView : PresentableView<PlayerWalletPresenter>, IPlayerWalletView
    {
        [Required] [SerializeField] private UiText _coinsUiText;

        public IUiText CoinsUiText => _coinsUiText;
    }
}