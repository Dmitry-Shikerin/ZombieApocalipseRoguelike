using System.Collections.Generic;
using Sources.Controllers.Presenters.Characters;
using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;
using UnityEngine;

namespace Sources.Presentations.Views.Characters.EnemyIndicators
{
    public class EnemyIndicatorView : PresentableView<EnemyIndicatorPresenter>, IEnemyIndicatorView
    {
        [SerializeField] private List<EnemyIndicatorArrow> _arrows;

        public Vector3 Position => transform.position;
        public IReadOnlyList<IEnemyIndicatorArrow> Arrows => _arrows;
        
    }
}