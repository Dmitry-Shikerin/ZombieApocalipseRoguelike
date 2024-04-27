using Sources.Controllers.Common.Forms.MainMenu;
using Sources.Controllers.Presenters.Forms.MainMenu;
using Sources.Infrastructure.Factories.Domain.Forms.MainMenu;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.MainMenu
{
    public class MainMenuSettingsFormView : FormBase<MainMenuSettingsFormPresenter>, IMainMenuSettingsFormView
    {
        [SerializeField] private ButtonView _mainMenuHudButtonView;
        
        public IButtonView MainMenuHudButtonView => _mainMenuHudButtonView;
    }
}