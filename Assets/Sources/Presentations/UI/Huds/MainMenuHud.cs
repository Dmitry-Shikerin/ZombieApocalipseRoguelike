using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.Presentations.Views.YandexSDK;
using UnityEngine;

namespace Sources.Presentations.UI.Huds
{
    public class MainMenuHud: View
    {
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private MainMenuHudFormView _mainMenuHudFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private MainMenuSettingsFormView _settingsFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private AuthorizationFormView _authorizationFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private LeaderBoardFormView _leaderBoardFormView;

        [Button(ButtonSizes.Large)]
        [FoldoutGroup("LeaderBoardElementViews")] [Required] [SerializeField]
        private List<LeaderBoardElementView> _leaderBoardElementViews;

        public MainMenuHudFormView MainMenuHudFormView => _mainMenuHudFormView;
        public MainMenuSettingsFormView SettingsFormView => _settingsFormView;
        public AuthorizationFormView AuthorizationFormView => _authorizationFormView;
        public LeaderBoardFormView LeaderBoardFormView => _leaderBoardFormView;
        
        public IReadOnlyList<LeaderBoardElementView> LeaderBoardElementViews => _leaderBoardElementViews;
    }
}