﻿using Sources.Domain.Models.Enemies.Base;
using UnityEngine;

namespace Sources.Domain.Models.Enemies.Bosses
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
        public float CurrentTimeAbility { get; set; }
        public float CurrentTimeRunning { get; set; }
        public bool IsRun { get; set; }
    }
}