using Sirenix.OdinInspector;
using Sources.Controllers.Forms.MainMenu;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.MainMenu
{
    public class MainMenuHudFormView : FormBase<MainMenuHudFormPresenter>, IMainMenuHudFormView
    {
        [Required] [SerializeField] private ButtonView _settingsButtonView;

        public IButtonView SettingsButtonView => _settingsButtonView;
    }
}