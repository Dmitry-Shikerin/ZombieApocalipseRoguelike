using Sirenix.OdinInspector;
using Sources.Controllers.Forms.MainMenu;
using Sources.Presentations.UI.Buttons;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Common
{
    public class SettingsFormView : FormBase<SettingsFormPresenter>, ISettingsFormView
    {
        [Required] [SerializeField] private ButtonView _mainMenuHudFormButtonView;

        public IButtonView MainMenuHudButtonView => _mainMenuHudFormButtonView;
    }
}