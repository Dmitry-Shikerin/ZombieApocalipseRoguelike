using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay.Tutorials
{
    public class HealthBarTutorialFormView : FormBase<HealthBarTutorialFormPresenter>, IHealthBarTutorialFormView
    {
        [Required] [SerializeField] private ButtonView _greetingTutorialButton;
        [Required] [SerializeField] private ButtonView _killEnemyCounterTutorialButton;
        [Required] [SerializeField] private ButtonView _hudFormButton;

        public IButtonView GreetingTutorialButton => _greetingTutorialButton;
        public IButtonView KillEnemyCounterTutorialButton => _killEnemyCounterTutorialButton;
        public IButtonView HudFormButton => _hudFormButton;
    }
}