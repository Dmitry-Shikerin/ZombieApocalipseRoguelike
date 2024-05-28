using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.MainMenu;
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
        [Required] [SerializeField] private ButtonView _leaderBoardButtonView;
        [Required] [SerializeField] private ButtonView _newGameButtonView;
        [Required] [SerializeField] private ButtonView _loadGameButtonView;
        
        public IButtonView SettingsButtonView => _settingsButtonView;
        public IButtonView LeaderBoardButtonView => _leaderBoardButtonView;
        public IButtonView NewGameButtonView => _newGameButtonView;
        public IButtonView LoadGameButtonView => _loadGameButtonView;
    }
}