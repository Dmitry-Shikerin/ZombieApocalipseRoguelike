using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Presentation.Views;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Cameras;
using Sources.Presentations.Views.Common;
using Sources.Presentations.Views.Gameplay;
using Sources.Presentations.Views.Music;
using Sources.Presentations.Views.Players;
using Sources.Presentations.Views.Settings;
using Sources.Presentations.Views.Upgrades;
using Sources.Presentations.Views.Upgrades.Controllers;
using UnityEngine;

namespace Sources.Presentations.UI.Huds
{
    public class GameplayHud : View, IHud
    {
        [FoldoutGroup("UiCollector")] [Required]
        [SerializeField] private UiCollector _uiCollector;
        [FoldoutGroup("Camera")] [Required]
        [SerializeField] private CinemachineCameraView _cinemachineCameraView;
        [FoldoutGroup("Upgrades")] [Required]
        [SerializeField] private List<UpgradeUi> _notAvailabilityUpgradeUis;
        [FoldoutGroup("Upgrades")] [Required]
        [SerializeField] private UpgradeControllerView _upgradeControllerView;
        [FoldoutGroup("PlayerWallet")] [Required]
        [SerializeField] private List<PlayerWalletView> _playerWalletViews;
        [FoldoutGroup("KillEnemyCounter")] [Required]
        [SerializeField] private KillEnemyCounterView _killEnemyCounterView;
        [FoldoutGroup("BackgroundMusic")] [Required]
        [SerializeField] private BackgroundMusicView _backgroundMusicView;
        [FoldoutGroup("HealthUi")] [Required]
        [SerializeField] private HealthUi _characterHealthUi;
        [FoldoutGroup("Volume")] [Required]
        [SerializeField] private VolumeView _volumeView;
        [FoldoutGroup("ScoreCounter")][Required]
        [SerializeField] private ScoreCounterView _scoreCounterView;

        public UiCollector UiCollector => _uiCollector;

        public CinemachineCameraView CinemachineCameraView => _cinemachineCameraView;

        public IReadOnlyList<UpgradeUi> NotAvailabilityUpgradeUis => _notAvailabilityUpgradeUis;

        public UpgradeControllerView UpgradeControllerView => _upgradeControllerView;

        public IReadOnlyList<PlayerWalletView> PlayerWalletViews => _playerWalletViews;

        public KillEnemyCounterView KillEnemyCounterView => _killEnemyCounterView;

        public BackgroundMusicView BackgroundMusicView => _backgroundMusicView;

        public HealthUi CharacterHealthUi => _characterHealthUi;

        public VolumeView VolumeView => _volumeView;

        public ScoreCounterView ScoreCounterView => _scoreCounterView;
    }
}