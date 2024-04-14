using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Character.EnemyIndicators
{
    public interface IEnemyIndicatorArrow : IView
    {
        Vector3 Forward { get; }
        Vector3 Position { get; }
        
        void SetUpward(Vector3 up);
        void SetAngleEuler(Vector3 angle);
        void SetLookRotation(float angle);
    }
}