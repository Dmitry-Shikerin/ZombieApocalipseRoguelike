using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.YandexSdcFramework.Presentations.Views;
using Sources.Presentations.BindableViews.Forms.MainMenu;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.Presentations.Views.Gameplay;
using Sources.Presentations.Views.Music;
using Sources.Presentations.Views.Settings;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.UI.Huds
{
    public class MainMenuHud: View, IHud
    {
        [FormerlySerializedAs("_mainMenuHudFormView")]
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("UiCollector")] [Required] [SerializeField]
        private UiCollector _uiCollector;

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

        public UiCollector UiCollector => _uiCollector;
        
        public IReadOnlyList<LeaderBoardElementView> LeaderBoardElementViews => _leaderBoardElementViews;
        
        public VolumeView VolumeView => _volumeView;
        
        public LevelAvailabilityView LevelAvailabilityView => _levelAvailabilityView;
        
        public BackgroundMusicView BackgroundMusicView => _backgroundMusicView;
    }
}