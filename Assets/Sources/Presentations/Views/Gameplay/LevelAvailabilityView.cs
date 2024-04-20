using System.Collections.Generic;
using Sources.Controllers.Gameplay;
using Sources.Presentations.UI.Buttons;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Gameplay
{
    public class LevelAvailabilityView : PresentableView<LevelAvailabilityPresenter>, ILevelAvailabilityView
    {
        [SerializeField] private List<ButtonView> _levelButtons;
        
        public IReadOnlyList<IButtonView> LevelButtons => _levelButtons;
    }
}