using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies
{
    public class EnemyHealthView : View, IEnemyHealthView
    {
        public Vector3 Position { get; }
        public void TakeDamage(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}