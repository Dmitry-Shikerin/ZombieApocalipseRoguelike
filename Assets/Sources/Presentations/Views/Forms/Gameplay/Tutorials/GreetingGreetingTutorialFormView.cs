using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay.Tutorials
{
    public class GreetingGreetingTutorialFormView : FormBase<GreetingTutorialFormPresenter>, IGreetingTutorialFormView
    {
        [Required] [SerializeField] private ButtonView _hudButtonView;
        [Required] [SerializeField] private ButtonView _healthBarTutorialButtonView;

        public IButtonView GameplayHudButtonView => _hudButtonView;
        public IButtonView HeathBarTutorialButtonView => _healthBarTutorialButtonView;
    }
}