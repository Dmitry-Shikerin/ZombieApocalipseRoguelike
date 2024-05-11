using System;
using JetBrains.Annotations;
using Sources.Presentations.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies.Bosses
{
    public class BossEnemyAnimation : EnemyAnimation, IBossEnemyAnimation
    {
        [SerializeField] private Animator _animator;
        
        private static int s_isRun = Animator.StringToHash("IsRun");
        
        public event Action Attacking;
        public event Action ScreamAnimationEnded;

        protected override void OnAfterAwake() =>
            StoppingAnimations.Add(StopRun);

        public void PlayRun()
        {
            ExceptAnimation(StopRun);
            _animator.SetBool(s_isRun, true);
        }

        private void StopRun()
        {
            if(_animator.GetBool(s_isRun) == false)
                return;
            
            _animator.SetBool(s_isRun, false);
        }
        
        [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();
        
        [UsedImplicitly]
        private void OnScreamAnimationEnded() =>
            ScreamAnimationEnded?.Invoke();
    }
}