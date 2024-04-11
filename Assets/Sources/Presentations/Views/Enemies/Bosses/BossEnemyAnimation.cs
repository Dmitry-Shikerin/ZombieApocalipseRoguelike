using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies.Bosses
{
    public class BossEnemyAnimation : View, IBossEnemyAnimation
    {
        [SerializeField] private Animator _animator;
        
        private readonly List<Action> _stoppingAnimations = new List<Action>();
        
        public event Action Attacking;
        public event Action ScreamAnimationEnded;

        //TODO триггеры нужно крутить в апдейте?
        private void Awake()
        {
            _stoppingAnimations.Add(StopIdle);
            _stoppingAnimations.Add(StopAttack);
            // _stoppingAnimations.Add(StopDie);
            _stoppingAnimations.Add(StopWalk);
            _stoppingAnimations.Add(StopScream);
            _stoppingAnimations.Add(StopRun);
        }

        public void PlayScream()
        {
            ExceptAnimation(StopScream);
            
            _animator.SetBool("IsScream", true);
        }

        private void StopScream()
        {
            if(_animator.GetBool("IsScream") == false)
                return;
            
            _animator.SetBool("IsScream", false);
        }

        public void PlayRun()
        {
            ExceptAnimation(StopRun);
            
            _animator.SetBool("IsRun", true);
        }

        private void StopRun()
        {
            if(_animator.GetBool("IsRun") == false)
                return;
            
            _animator.SetBool("IsRun", false);
        }

        public void PlayWalk()
        {
            ExceptAnimation(StopWalk);
            
            _animator.SetBool("IsWalk", true);
        }

        public void PlayIdle()
        {
            ExceptAnimation(StopIdle);
            
            _animator.SetBool("IsIdle", true);
        }

        // public void PlayDie()
        // {
        //     ExceptAnimation(StopDie);
        //     
        //     _animator.SetBool("IsDeath", true);
        // }

        public void PlayAttack()
        {
            ExceptAnimation(StopAttack);
            
            _animator.SetBool("IsAttack", true);
        }
        
        [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();

        private void StopWalk()
        {
            if(_animator.GetBool("IsWalk") == false)
                return;
            
            _animator.SetBool("IsWalk", false);

        }

        private void StopIdle()
        {
            if(_animator.GetBool("IsIdle") == false)
                return;
            
            _animator.SetBool("IsIdle", false);

        }

        private void StopAttack()
        {
            if(_animator.GetBool("IsAttack") == false)
                return;
            
            _animator.SetBool("IsAttack", false);

        }
        
        // private void StopDie()
        // {
        //     if(_animator.GetBool("IsDeath") == false)
        //         return;
        //     
        //     _animator.SetBool("IsDeath", false);
        // }

        [UsedImplicitly]
        private void OnScreamAnimationEnded()
        {
            ScreamAnimationEnded?.Invoke();
        }
        
        private void ExceptAnimation(Action exceptAnimation)
        {
            foreach (Action animation in _stoppingAnimations)
            {
                if(animation == exceptAnimation)
                    continue;
                
                animation.Invoke();
            }
        }
    }
}