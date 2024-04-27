using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.Views.Forms.Gameplay.Tutorials
{
    public class SaveTutorialFormView : FormBase<SaveTutorialFormPresenter>, ISaveTutorialFormView
    {
        [SerializeField] private ButtonView _killEnemyCounterTutorialButton;
        [SerializeField] private ButtonView _rewardTutorialButton;
        [SerializeField] private ButtonView _hudFormButton;

        public IButtonView KillEnemyCounterTutorialButton => _killEnemyCounterTutorialButton;
        public IButtonView RewardTutorialButton => _rewardTutorialButton;
        public IButtonView HudFormButton => _hudFormButton;
    }
}