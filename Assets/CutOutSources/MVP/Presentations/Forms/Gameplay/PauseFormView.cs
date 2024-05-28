using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay
{
    public class PauseFormView : FormBase<PauseFormPresenter>, IPauseFormView
    {
        [Required] [SerializeField] private ButtonView _hudButtonView;
        [Required] [SerializeField] private ButtonView _mainMenuButtonView;
        [Required] [SerializeField] private ButtonView _tutorialButtonView;
        [Required] [SerializeField] private ButtonView _settingsButtonView;

        public IButtonView HudButtonView => _hudButtonView;
        public IButtonView MainMenuButtonView => _mainMenuButtonView;
        public IButtonView TutorialButtonView => _tutorialButtonView;
        public IButtonView SettingsButtonView => _settingsButtonView;
    }
}