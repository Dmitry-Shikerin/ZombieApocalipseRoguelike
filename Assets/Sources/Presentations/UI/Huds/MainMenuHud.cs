using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Forms.MainMenu;
using UnityEngine;

namespace Sources.Presentations.UI.Huds
{
    public class MainMenuHud: View
    {
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private MainMenuHudFormView _mainMenuHudFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private SettingsFormView _settingsFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private AuthorizationFormView _authorizationFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private LeaderBoardFormView _leaderBoardFormView;

        public MainMenuHudFormView MainMenuHudFormView => _mainMenuHudFormView;
        public SettingsFormView SettingsFormView => _settingsFormView;
        public AuthorizationFormView AuthorizationFormView => _authorizationFormView;
        public LeaderBoardFormView LeaderBoardFormView => _leaderBoardFormView;
    }
}