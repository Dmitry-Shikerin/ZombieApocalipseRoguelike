using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyHealthView
    {
        Vector3 Position { get; }

        float CurrentHealth { get; }

        void TakeDamage(float damage);

        public void PlayBloodParticle();
    }
}