using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Presentation.Views;
using Sources.Frameworks.YandexSdcFramework.Presentations.Views;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Gameplay;
using Sources.Presentations.Views.Music;
using Sources.Presentations.Views.Settings;
using UnityEngine;

namespace Sources.Presentations.UI.Huds
{
    public class MainMenuHud: View, IHud
    {
        [FoldoutGroup("UiCollector")] [Required] 
        [SerializeField] private UiCollector _uiCollector;
        [FoldoutGroup("LeaderBoardElementViews")] [Required] 
        [SerializeField] private List<LeaderBoardElementView> _leaderBoardElementViews;
        [FoldoutGroup("Settings")] [Required] 
        [SerializeField] private VolumeView _volumeView;
        [FoldoutGroup("LevelAvailability")] [Required] 
        [SerializeField] private LevelAvailabilityView _levelAvailabilityView;
        [FoldoutGroup("BackgroundMusic")] [Required] 
        [SerializeField] private BackgroundMusicView _backgroundMusicView;

        public UiCollector UiCollector => _uiCollector;
        public IReadOnlyList<LeaderBoardElementView> LeaderBoardElementViews => _leaderBoardElementViews;
        public VolumeView VolumeView => _volumeView;
        public LevelAvailabilityView LevelAvailabilityView => _levelAvailabilityView;
        public BackgroundMusicView BackgroundMusicView => _backgroundMusicView;
    }
}