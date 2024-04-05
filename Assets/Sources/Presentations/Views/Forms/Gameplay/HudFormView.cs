using Sirenix.OdinInspector;
using Sources.Controllers.Forms.Gameplay;
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
        
        public IButtonView PauseButtonView => _pauseButtonView;
    }
}