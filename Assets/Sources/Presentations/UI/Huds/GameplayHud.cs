using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Cameras;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Players;
using Sources.Presentations.Views.Upgrades;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.UI.Huds
{
    public class GameplayHud : View
    {
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private PauseFormView _pauseFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private HudFormView _hudFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private UpgradeFormView _upgradeFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private TutorialFormView _tutorialFormView;
        [FoldoutGroup("Forms")] [Required] [SerializeField]
        private GameplaySettingsFormView _settingsFormView;
        
        [FormerlySerializedAs("_cinemachineCameraService")]
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Camera")] [Required] [SerializeField]
        private CinemachineCameraView cinemachineCameraView;

        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Upgrades")] [Required] [SerializeField]
        private List<UpgradeView> _upgradeViews;
        [FoldoutGroup("Upgrades")] [Required] [SerializeField]
        private List<UpgradeUi> _upgradeUis;
        
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("PlayerWallet")] [Required] [SerializeField]
        private PlayerWalletView _playerWalletView;


        public PauseFormView PauseFormView => _pauseFormView;
        public HudFormView HudFormView => _hudFormView;
        public UpgradeFormView UpgradeFormView => _upgradeFormView;
        public TutorialFormView TutorialFormView => _tutorialFormView;
        public GameplaySettingsFormView SettingsFormView => _settingsFormView;
        
        public CinemachineCameraView CinemachineCameraView => cinemachineCameraView;

        public IReadOnlyList<UpgradeView> UpgradeViews => _upgradeViews;
        public IReadOnlyList<UpgradeUi> UpgradeUis => _upgradeUis;
        
        public PlayerWalletView PlayerWalletView => _playerWalletView;
    }
}