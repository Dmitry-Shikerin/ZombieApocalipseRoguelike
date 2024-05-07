using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Presentations.Views.Bears
{
    public class BearAnimationView : View, IBearAnimationView
    {
        [Required] [SerializeField] private Animator _animator;
        
        private static int s_isWalk = Animator.StringToHash("IsWalk");
        private static int s_isIdle = Animator.StringToHash("IsIdle");
        private static int s_isAttack = Animator.StringToHash("IsAttack");
        
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
            StopAnimationExcept(StopPlayWalk);
            
            _animator.SetBool(s_isWalk, true);
        }

        public void PlayIdle()
        {
            StopAnimationExcept(StopPlayIdle);
            
            _animator.SetBool(s_isIdle, true);
        }

        public void PlayAttack()
        {
            StopAnimationExcept(StopPlayAttack);
            
            _animator.SetBool(s_isAttack, true);
        }
        
        private void StopPlayWalk()
        {
            if(_animator.GetBool(s_isWalk) == false)
                return;
            
            _animator.SetBool(s_isWalk, false);
        }
        
        private void StopPlayIdle()
        {
            if(_animator.GetBool(s_isIdle) == false)
                return;
            
            _animator.SetBool(s_isIdle, false);
        }
        
        private void StopPlayAttack()
        {
            if(_animator.GetBool(s_isAttack) == false)
                return;
            
            _animator.SetBool(s_isAttack, false);
        }
        
        [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();

        private void StopAnimationExcept(Action exceptAction)
        {
            _stoppingAnimations
                .Except(new List<Action>() { exceptAction })
                .ForEach(action => action.Invoke());
        }
    }
}