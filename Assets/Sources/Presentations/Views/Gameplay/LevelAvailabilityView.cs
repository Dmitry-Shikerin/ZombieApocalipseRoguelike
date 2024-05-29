using System.Collections.Generic;
using Sources.Controllers.Presenters.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Gameplay
{
    public class LevelAvailabilityView : PresentableView<LevelAvailabilityPresenter>, ILevelAvailabilityView
    {
        [SerializeField] private List<LevelView> _levelViews;

        public IReadOnlyList<ILevelView> Levels => _levelViews;
    }
}