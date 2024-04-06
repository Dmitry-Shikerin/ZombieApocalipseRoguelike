using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.Views.Bears
{
    public class BearAnimationView : View, IBearAnimationView
    {
        [Required] [SerializeField] private Animator _animator;
        
        private readonly List<Action> _stoppingAnimations = new List<Action>();
        
        public event Action Attacking;

        private void Awake()
        {
            _stoppingAnimations.Add(StopPlayWalk);
            _stoppingAnimations.Add(StopPlayIdle);
            _stoppingAnimations.Add(StopPlayAttack);
        }

        public void PlayWalk()
        {
            ExceptAnimation(StopPlayWalk);
            
            _animator.SetBool("IsWalk", true);
        }

        public void PlayIdle()
        {
            ExceptAnimation(StopPlayIdle);
            
            _animator.SetBool("IsIdle", true);
        }

        public void PlayAttack()
        {
            ExceptAnimation(StopPlayAttack);
            
            _animator.SetBool("IsAttack", true);
        }
        
        private void StopPlayWalk()
        {
            if(_animator.GetBool("IsWalk") == false)
                return;
            
            _animator.SetBool("IsWalk", false);
        }
        
        private void StopPlayIdle()
        {
            if(_animator.GetBool("IsIdle") == false)
                return;
            
            _animator.SetBool("IsIdle", false);
        }
        
        private void StopPlayAttack()
        {
            if(_animator.GetBool("IsAttack") == false)
                return;
            
            _animator.SetBool("IsAttack", false);
        }
        
        // [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();

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