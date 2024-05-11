using Sirenix.OdinInspector;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.MainMenu
{
    public class LeaderboardFormView : FormBase<LeaderboardFormPresenter>, ILeaderBoardFormView
    {
        [Required] [SerializeField] private ButtonView _mainMenuHudButtonView;

        public IButtonView MainMenuHudButtonView => _mainMenuHudButtonView;
    }
}