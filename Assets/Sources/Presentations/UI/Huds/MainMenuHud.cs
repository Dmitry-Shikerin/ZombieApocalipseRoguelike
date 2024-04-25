using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Presentations.BindableViews.Forms.MainMenu;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Gameplay;
using Sources.Presentations.Views.Music;
using Sources.Presentations.Views.Settings;
using Sources.Presentations.Views.YandexSDK;
using UnityEngine;

namespace Sources.Presentations.UI.Huds
{
    public class MainMenuHud: View
    {
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private MainMenuHudFormBindableView _mainMenuHudFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private AuthorizationFormBindableView _authorizationFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private MainMenuSettingsFormBindableView _mainMenuSettingsFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private LeaderboardFormBindableView _leaderboardFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private NewGameFormBindableView _newGameFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private WarningNewGameFormBindableView _warningNewGameFormBindableView;

        [Button(ButtonSizes.Large)]
        [FoldoutGroup("LeaderBoardElementViews")] [Required] [SerializeField]
        private List<LeaderBoardElementView> _leaderBoardElementViews;
        
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Settings")] [Required] [SerializeField]
        private VolumeView _volumeView;
        
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("LevelAvailability")] [Required] [SerializeField]
        private LevelAvailabilityView _levelAvailabilityView;
        
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("BackgroundMusic")] [Required] [SerializeField]
        private BackgroundMusicView _backgroundMusicView;

        public MainMenuHudFormBindableView MainMenuHudFormBindableView => _mainMenuHudFormBindableView;
        public AuthorizationFormBindableView AuthorizationFormBindableView => _authorizationFormBindableView;
        public MainMenuSettingsFormBindableView MainMenuSettingsFormBindableView => _mainMenuSettingsFormBindableView;
        public LeaderboardFormBindableView LeaderboardFormBindableView => _leaderboardFormBindableView;
        public NewGameFormBindableView NewGameFormBindableView => _newGameFormBindableView;
        public WarningNewGameFormBindableView WarningNewGameFormBindableView => _warningNewGameFormBindableView;
        public IReadOnlyList<LeaderBoardElementView> LeaderBoardElementViews => _leaderBoardElementViews;
        
        public VolumeView VolumeView => _volumeView;
        
        public LevelAvailabilityView LevelAvailabilityView => _levelAvailabilityView;
        
        public BackgroundMusicView BackgroundMusicView => _backgroundMusicView;
    }
}