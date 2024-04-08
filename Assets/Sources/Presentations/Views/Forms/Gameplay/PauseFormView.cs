using Sirenix.OdinInspector;
using Sources.Controllers.Forms.Gameplay;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Presentations.Views.Forms.Gameplay
{
    public class PauseFormView : FormBase<PauseFormPresenter>, IPauseFormView
    {
        [Required] [SerializeField] private ButtonView _hudButtonView;
        [Required] [SerializeField] private ButtonView _mainMenuButtonView;
        [Required] [SerializeField] private ButtonView _settingsButtonView;
        [Required] [SerializeField] private ButtonView _tutorialButtonView;

        public IButtonView HudButtonView => _hudButtonView;
        public IButtonView MainMenuButtonView => _mainMenuButtonView;

        public IButtonView SettingsButtonView => _settingsButtonView;
        public IButtonView TutorialButtonView => _tutorialButtonView;
    }
}