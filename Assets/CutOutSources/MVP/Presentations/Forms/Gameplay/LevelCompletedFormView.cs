using Sirenix.OdinInspector;
using Sources.Controllers.Common.Forms;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay
{
    public class LevelCompletedFormView : FormBase<LevelCompletedFormPresenter>, ILevelCompletedFormView
    {
        [Required] [SerializeField] private ButtonView _backToMainMenuButtonView;
        
        public IButtonView BackToMainMenuButtonView => _backToMainMenuButtonView;
    }
}