using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay;
using Sources.Presentations.BindableViews.Forms.Gameplay;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Cameras;
using Sources.Presentations.Views.Common;
using Sources.Presentations.Views.Gameplay;
using Sources.Presentations.Views.Localizations;
using Sources.Presentations.Views.Music;
using Sources.Presentations.Views.Players;
using Sources.Presentations.Views.Settings;
using Sources.Presentations.Views.Upgrades;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.UI.Huds
{
    public class GameplayHud : View
    {
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private PauseFormBindableView _pauseFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private GameplayHudFormBindableView _gameplayHudFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private GameplaySettingsFormBindableView _gameplaySettingsFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private UpgradeFormBindableView _upgradeFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private GameOverFormBindableView _gameOverFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private LevelCompletedFormBindableView _levelCompletedFormBindableView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private TutorialFormBindableView _tutorialFormBindableView;

        [FormerlySerializedAs("cinemachineCameraView")]
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Camera")] [Required] [SerializeField]
        private CinemachineCameraView _cinemachineCameraView;
        
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Localizations")] [Required] [SerializeField]
        private LocalizationView _localizationView;

        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Containers")] [Required] [SerializeField]
        private ContainerView _formServiceContainerView;
        [FoldoutGroup("Containers")] [Required] [SerializeField]
        private ContainerView _tutorialFormServiceContainerView;

        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Upgrades")] [Required] [SerializeField]
        private List<UpgradeView> _upgradeViews;
        [FoldoutGroup("Upgrades")] [Required] [SerializeField]
        private List<UpgradeUi> _upgradeUis;
        [FormerlySerializedAs("notAvailabilityUpgradeUis")] [FormerlySerializedAs("_notAwailabilityUpgradeUis")] [FoldoutGroup("Upgrades")] [Required] [SerializeField]
        private List<UpgradeUi> _notAvailabilityUpgradeUis;
        
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("PlayerWallet")] [Required] [SerializeField]
        private PlayerWalletView _playerWalletView;

        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("KillEnemyCounter")] [Required] [SerializeField]
        private KillEnemyCounterView _killEnemyCounterView;
        
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("BackgroundMusic")] [Required] [SerializeField]
        private BackgroundMusicView _backgroundMusicView;

        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("HealthUi")] [Required] [SerializeField]
        private HealthUi _characterHealthUi;
        
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Volume")] [Required] [SerializeField]
        private VolumeView _volumeView;
        
        public PauseFormBindableView PauseFormBindableView => _pauseFormBindableView;
        public GameplayHudFormBindableView GameplayHudFormBindableView => _gameplayHudFormBindableView;
        public GameplaySettingsFormBindableView GameplaySettingsFormBindableView => _gameplaySettingsFormBindableView;
        public UpgradeFormBindableView UpgradeFormBindableView => _upgradeFormBindableView;
        public GameOverFormBindableView GameOverFormBindableView => _gameOverFormBindableView;
        public LevelCompletedFormBindableView LevelCompletedFormBindableView => _levelCompletedFormBindableView;
        public TutorialFormBindableView TutorialFormBindableView => _tutorialFormBindableView;
        
        public CinemachineCameraView CinemachineCameraView => _cinemachineCameraView;

        public LocalizationView LocalizationView => _localizationView;

        public ContainerView FormServiceContainerView => _formServiceContainerView;
        public ContainerView TutorialFormServiceContainerView => _tutorialFormServiceContainerView;

        public IReadOnlyList<UpgradeView> UpgradeViews => _upgradeViews;
        public IReadOnlyList<UpgradeUi> UpgradeUis => _upgradeUis;
        public IReadOnlyList<UpgradeUi> NotAvailabilityUpgradeUis => _notAvailabilityUpgradeUis;
        
        public PlayerWalletView PlayerWalletView => _playerWalletView;

        public KillEnemyCounterView KillEnemyCounterView => _killEnemyCounterView;
        
        public BackgroundMusicView BackgroundMusicView => _backgroundMusicView;
        
        public HealthUi CharacterHealthUi => _characterHealthUi;
        
        public VolumeView VolumeView => _volumeView;
    }
}