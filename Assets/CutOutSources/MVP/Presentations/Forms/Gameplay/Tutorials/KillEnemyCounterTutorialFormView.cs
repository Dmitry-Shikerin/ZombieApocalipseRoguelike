using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay.Tutorials
{
    public class KillEnemyCounterTutorialFormView : FormBase<KillEnemyCounterTutorialPresenter>, 
        IKillEnemyCounterTutorialFormView
    {
        [Required] [SerializeField] private ButtonView _healthBarTutorialButton;
        [Required] [SerializeField] private ButtonView _saveTutorialButton;
        [Required] [SerializeField] private ButtonView _mainMenuButton;
        
        public IButtonView HealthBarTutorialButton => _healthBarTutorialButton;
        public IButtonView SaveTutorialButton => _saveTutorialButton;
        public IButtonView MainMenuButton => _mainMenuButton;
    }
}