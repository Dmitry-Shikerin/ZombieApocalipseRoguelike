using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies
{
    public class EnemyAnimation : View, IEnemyAnimation
    {
        [Required] [SerializeField] private Animator _animator;
        
        private readonly List<Action> _stoppingAnimations = new List<Action>();

        private void Awake()
        {
            _stoppingAnimations.Add(StopIdle);
            _stoppingAnimations.Add(StopAttack);
            _stoppingAnimations.Add(StopDie);
            _stoppingAnimations.Add(StopWalk);
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

        public void PlayDie()
        {
            ExceptAnimation(StopDie);
            
            _animator.SetBool("IsDeath", true);
        }

        public void PlayAttack()
        {
            ExceptAnimation(StopAttack);
            
            _animator.SetBool("IsAttack", true);
        }

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
        
        private void StopDie()
        {
            if(_animator.GetBool("IsDeath") == false)
                return;
            
            _animator.SetBool("IsDeath", false);
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