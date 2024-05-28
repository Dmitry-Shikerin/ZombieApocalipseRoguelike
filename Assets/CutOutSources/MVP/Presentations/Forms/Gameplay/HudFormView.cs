using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay
{
    public class HudFormView : FormBase<HudFormPresenter>, IHudFormView
    {
        [Required] [SerializeField] private ButtonView _pauseButtonView;
        [Required] [SerializeField] private ButtonView _upgradeButtonView;
        
        public IButtonView PauseButtonView => _pauseButtonView;
        public IButtonView UpgradeButtonView => _upgradeButtonView;
    }
}