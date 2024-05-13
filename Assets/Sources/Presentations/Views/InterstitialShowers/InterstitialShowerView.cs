using Sirenix.OdinInspector;
using Sources.Controllers.Common.InterstitialShowers;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.InterstitialShowers;
using UnityEngine;

namespace Sources.Presentations.Views.InterstitialShowers
{
    public class InterstitialShowerView : PresentableView<InterstitialShowerPresenter>, IInterstitialShowerView
    {
        [Required] [SerializeField] private UiText _timerText;

        public IUiText TimerText => _timerText;
    }
}