using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Cameras;
using Sources.Presentations.Views.Common;
using Sources.Presentations.Views.Gameplay;
using Sources.Presentations.Views.InterstitialShowers;
using Sources.Presentations.Views.Music;
using Sources.Presentations.Views.Players;
using Sources.Presentations.Views.Settings;
using Sources.Presentations.Views.Upgrades;
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
        [SerializeField] private List<UpgradeView> _upgradeViews;
        [FoldoutGroup("Upgrades")] [Required] 
        [SerializeField] private List<UpgradeUi> _upgradeUis;
        [FoldoutGroup("Upgrades")] [Required] 
        [SerializeField] private List<UpgradeUi> _notAvailabilityUpgradeUis;
        [FoldoutGroup("Upgrades")] [Required] 
        [SerializeField] private List<UpgradeDescriptionView> _upgradeDescriptionViews;
        
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

        [FoldoutGroup("InterstitialShower")][Required]
        [SerializeField] private InterstitialShowerView _interstitialShowerView;
        
        public UiCollector UiCollector => _uiCollector;
        
        public CinemachineCameraView CinemachineCameraView => _cinemachineCameraView;

        public IReadOnlyList<UpgradeView> UpgradeViews => _upgradeViews;
        public IReadOnlyList<UpgradeUi> UpgradeUis => _upgradeUis;
        public IReadOnlyList<UpgradeUi> NotAvailabilityUpgradeUis => _notAvailabilityUpgradeUis;
        public IReadOnlyList<UpgradeDescriptionView> UpgradeDescriptionViews => _upgradeDescriptionViews;
        
        public IReadOnlyList<PlayerWalletView> PlayerWalletViews => _playerWalletViews;

        public KillEnemyCounterView KillEnemyCounterView => _killEnemyCounterView;
        
        public BackgroundMusicView BackgroundMusicView => _backgroundMusicView;
        
        public HealthUi CharacterHealthUi => _characterHealthUi;
        
        public VolumeView VolumeView => _volumeView;
        public InterstitialShowerView InterstitialShowerView => _interstitialShowerView;
    }
}