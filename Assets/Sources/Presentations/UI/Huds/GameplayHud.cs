using Sirenix.OdinInspector;
using Sources.Presentations.Views;
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

        public PauseFormView PauseFormView => _pauseFormView;
        public HudFormView HudFormView => _hudFormView;
    }
}