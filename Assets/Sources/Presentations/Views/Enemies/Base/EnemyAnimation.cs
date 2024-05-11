using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sources.Presentations.Views.Animations;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies.Base
{
    public class EnemyAnimation : AnimationViewBase, IEnemyAnimation
    {
        [Required] [SerializeField] private Animator _animator;
        
        private static int s_isIdle = Animator.StringToHash("IsIdle");
        private static int s_isWalk = Animator.StringToHash("IsWalk");
        private static int s_isAttack = Animator.StringToHash("IsAttack");
        private static int s_isDeath = Animator.StringToHash("IsDeath");
        
        private void Awake()
        {
            StoppingAnimations.Add(StopIdle);
            StoppingAnimations.Add(StopAttack);
            StoppingAnimations.Add(StopDie);
            StoppingAnimations.Add(StopWalk);
            OnAfterAwake();
        }

        protected virtual void OnAfterAwake()
        {
        }
        
        public event Action Attacking;

        public void PlayWalk()
        {
            ExceptAnimation(StopWalk);
            _animator.SetBool(s_isWalk, true);
        }

        public void PlayIdle()
        {
            ExceptAnimation(StopIdle);
            _animator.SetBool(s_isIdle, true);
        }

        public void PlayDie()
        {
            ExceptAnimation(StopDie);
            _animator.SetBool(s_isDeath, true);
        }

        public void PlayAttack()
        {
            ExceptAnimation(StopAttack);
            _animator.SetBool(s_isAttack, true);
        }
        
        [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();
        
        private void StopWalk()
        {
            if(_animator.GetBool(s_isWalk) == false)
                return;
            
            _animator.SetBool(s_isWalk, false);
        
        }
        
        private void StopIdle()
        {
            if(_animator.GetBool(s_isIdle) == false)
                return;
            
            _animator.SetBool(s_isIdle, false);
        
        }
        
        private void StopAttack()
        {
            if(_animator.GetBool(s_isAttack) == false)
                return;
            
            _animator.SetBool(s_isAttack, false);
        
        }
        
        private void StopDie()
        {
            if(_animator.GetBool(s_isDeath) == false)
                return;
            
            _animator.SetBool(s_isDeath, false);
        }
    }
}