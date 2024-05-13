using System;
using JetBrains.Annotations;
using Sources.Presentations.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies.Bosses
{
    public class BossEnemyAnimation : EnemyAnimation, IBossEnemyAnimation
    {
        private static int s_isRun = Animator.StringToHash("IsRun");
        
        public event Action Attacking;
        public event Action ScreamAnimationEnded;

        protected override void OnAfterAwake() =>
            StoppingAnimations.Add(StopRun);

        public void PlayRun()
        {
            ExceptAnimation(StopRun);
            Animator.SetBool(s_isRun, true);
        }

        private void StopRun()
        {
            if(Animator.GetBool(s_isRun) == false)
                return;
            
            Animator.SetBool(s_isRun, false);
        }
        
        [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();
        
        [UsedImplicitly]
        private void OnScreamAnimationEnded() =>
            ScreamAnimationEnded?.Invoke();
    }
}