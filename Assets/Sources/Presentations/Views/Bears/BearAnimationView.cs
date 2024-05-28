using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Presentations.Views.Bears
{
    public class BearAnimationView : View, IBearAnimationView
    {
        [Required] [SerializeField] private Animator _animator;

        private static int s_isIdle = Animator.StringToHash("IsIdle");
        private static int s_isWalk = Animator.StringToHash("IsWalk");
        private static int s_isAttack = Animator.StringToHash("IsAttack");
        
        private readonly List<Action> _stoppingAnimations = new List<Action>();

        public event Action Attacking;
        
        private void Awake()
        {
            _stoppingAnimations.Add(StopIdle);
            _stoppingAnimations.Add(StopAttack);
            _stoppingAnimations.Add(StopWalk);
        }
        
        [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();
        
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
        
        public void PlayAttack()
        {
            ExceptAnimation(StopAttack);
            _animator.SetBool(s_isAttack, true);
        }
        
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