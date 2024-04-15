using System.Collections.Generic;
using Sources.Presentations.Views.Characters.EnemyIndicators;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Character.EnemyIndicators
{
    public interface IEnemyIndicatorView
    {
        Vector3 Position { get;}
        IReadOnlyList<IEnemyIndicatorArrow> Arrows { get; }
    }
}