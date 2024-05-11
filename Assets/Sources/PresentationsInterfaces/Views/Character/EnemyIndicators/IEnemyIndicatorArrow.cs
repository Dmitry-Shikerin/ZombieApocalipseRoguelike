using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Character.EnemyIndicators
{
    public interface IEnemyIndicatorArrow : IView
    {
        void SetAngleEuler(Vector3 angle);
    }
}