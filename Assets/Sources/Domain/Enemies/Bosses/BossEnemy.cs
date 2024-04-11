using Sources.Domain.Enemies.Base;
using UnityEngine;

namespace Sources.Domain.Enemies.Bosses
{
    public class BossEnemy : Enemy
    {
        public BossEnemy(
            EnemyHealth enemyHealth,
            EnemyAttacker enemyAttacker,
            float stunTime,
            float walkSpeed,
            float runSpeed) 
            : base(
                enemyHealth, 
                enemyAttacker)
        {
            StunTime = stunTime;
            WalkSpeed = walkSpeed;
            RunSpeed = runSpeed;
        }
        
        public float StunTime { get; }
        public float WalkSpeed { get; }
        public float RunSpeed { get; }
        public bool IsIdle { get; set; } = true;
        public bool IsMassAttack { get; set; } = true;
        public bool IsRage { get; set; }
        public Vector3 Destination { get; set; }
        public float CurrentTimeAbility { get; set; }
    }
}