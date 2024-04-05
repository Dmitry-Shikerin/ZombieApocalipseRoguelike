using Sirenix.OdinInspector;
using Sources.Controllers.Forms.Gameplay;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay
{
    public class PauseFormView : FormBase<PauseFormPresenter>, IPauseFormView
    {
        [Required] [SerializeField] private ButtonView _hudButtonView;

        public IButtonView HudButtonView => _hudButtonView;
    }
}