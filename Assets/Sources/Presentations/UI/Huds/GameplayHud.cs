using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Cameras;
using Sources.Presentations.Views.Forms.Gameplay;
using UnityEngine;

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
        
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Camera")] [Required] [SerializeField]
        private CinemachineCameraService _cinemachineCameraService;


        public PauseFormView PauseFormView => _pauseFormView;
        public HudFormView HudFormView => _hudFormView;
        public UpgradeFormView UpgradeFormView => _upgradeFormView;
        
        public CinemachineCameraService CinemachineCameraService => _cinemachineCameraService;
    }
}