using System;

namespace Sources.Domain.Enemies
{
    public class Enemy
    {
        public Enemy(
            EnemyHealth enemyHealth,
            EnemyAttacker enemyAttacker)
        {
            EnemyHealth = enemyHealth ?? throw new ArgumentNullException(nameof(enemyHealth));
            EnemyAttacker = enemyAttacker;
        }

        public bool IsInitialized { get; set; }
        public EnemyHealth EnemyHealth { get; set; }
        public EnemyAttacker EnemyAttacker { get; }
    }
}