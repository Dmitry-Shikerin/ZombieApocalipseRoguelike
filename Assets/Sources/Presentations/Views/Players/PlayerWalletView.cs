using Sirenix.OdinInspector;
using Sources.Controllers.Players;
using Sources.Domain.Players;
using Sources.Presentations.UI.Texts;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Presentations.Views.Players
{
    public class PlayerWalletView : PresentableView<PlayerWalletPresenter>, IPlayerWalletView
    {
        [Required] [SerializeField] private TextView _coinsTextView;

        public ITextView CoinsTextView => _coinsTextView;
    }
}