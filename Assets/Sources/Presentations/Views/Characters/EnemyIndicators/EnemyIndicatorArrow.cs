using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;
using UnityEngine;

namespace Sources.Presentations.Views.Characters.EnemyIndicators
{
    public class EnemyIndicatorArrow : View, IEnemyIndicatorArrow
    {
        public void SetAngleEuler(Vector3 angle) =>
            transform.rotation = Quaternion.Euler(angle);
    }
}