using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;
using UnityEngine;

namespace Sources.Presentations.Views.Characters.EnemyIndicators
{
    public class EnemyIndicatorArrow : View, IEnemyIndicatorArrow
    {
        public Vector3 Forward => transform.forward;
        public Vector3 Position => transform.position;

        private void Awake()
        {
            // Debug.Log(Forward);
            // Debug.Log(Position);
            // Debug.Log();
        }

        public void SetUpward(Vector3 up)
        {
            transform.up = up;
        }

        public void SetAngleEuler(Vector3 angle)
        {
            transform.rotation = Quaternion.Euler(angle);
        }

        public void SetZRotation(float angle)
        {
        }

        public void SetLookRotation(float angle)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.Euler(0, 0, angle), 4f);
        }
    }
}