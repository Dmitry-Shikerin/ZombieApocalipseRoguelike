using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyHealthView
    {
        Vector3 Position { get; }
        
        void TakeDamage(float damage);
    }
}