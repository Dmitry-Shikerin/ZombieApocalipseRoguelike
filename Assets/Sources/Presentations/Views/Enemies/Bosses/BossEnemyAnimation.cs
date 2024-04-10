using System;
using JetBrains.Annotations;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies.Bosses
{
    public class BossEnemyAnimation : View, IBossEnemyAnimation
    {
        [SerializeField] private Animator _animator;
        
        public event Action Attacking;
        public event Action ScreamAnimationEnded;


        public void PlayWalk()
        {
            _animator.SetTrigger("Walk");
        }

        public void PlayIdle()
        {
            _animator.SetTrigger("Idle");
        }

        public void PlayDie()
        {
        }

        public void PlayAttack()
        {
            _animator.SetTrigger("Attack");
        }

        public void PlayRage()
        {
            _animator.SetTrigger("Rage");
        }

        public void PlayRun()
        {
            _animator.SetTrigger("Run");
        }

        [UsedImplicitly]
        private void OnScreamAnimationEnded()
        {
            ScreamAnimationEnded?.Invoke();
        }
    }
}