using Sirenix.OdinInspector;
using Sources.Controllers.Forms.MainMenu;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.MainMenu
{
    public class MainMenuSettingsFormView : FormBase<MainMenuSettingsFormPresenter>, IMainMenuSettingsFormView
    {
        [Required] [SerializeField] private ButtonView _mainMenuHudFormButtonView;

        public IButtonView MainMenuHudButtonView => _mainMenuHudFormButtonView;
    }
}