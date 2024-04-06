using System;

namespace Sources.Domain.Enemies
{
    public class Enemy
    {
        public Enemy(EnemyHealth enemyHealth)
        {
            EnemyHealth = enemyHealth ?? throw new ArgumentNullException(nameof(enemyHealth));
        }

        public bool IsInitialized { get; set; }
        public EnemyHealth EnemyHealth { get; set; }
    }
}