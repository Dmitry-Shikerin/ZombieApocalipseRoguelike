using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay;
using Sources.Presentations.BindableViews.Forms.Gameplay;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Cameras;
using Sources.Presentations.Views.Common;
using Sources.Presentations.Views.Forms.Gameplay;
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
        private TutorialFormView _tutorialFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private PauseFormView _pauseFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private HudFormView _hudFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private GameplaySettingsFormView _gameplaySettingsFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private UpgradeFormView _upgradeFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private GameOverFormView _gameOverFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private LevelCompletedFormView _levelCompletedFormView;
        

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
        
        public TutorialFormView TutorialFormView => _tutorialFormView;
        public PauseFormView PauseFormView => _pauseFormView;
        public HudFormView HudFormView => _hudFormView;
        public GameplaySettingsFormView GameplaySettingsFormView => _gameplaySettingsFormView;
        public UpgradeFormView UpgradeFormView => _upgradeFormView;
        public GameOverFormView GameOverFormView => _gameOverFormView;
        public LevelCompletedFormView LevelCompletedFormView => _levelCompletedFormView;
        
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