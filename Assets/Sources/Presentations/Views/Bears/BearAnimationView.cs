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
        
        private static int Idle = Animator.StringToHash("Idle");
        private static int Walk = Animator.StringToHash("Walk");
        private static int Attack = Animator.StringToHash("Attack");
        
        public event Action Attacking;

        public void PlayWalk() =>
            _animator.SetTrigger(Walk);

        public void PlayIdle() =>
            _animator.SetTrigger(Idle);

        public void PlayAttack() =>
            _animator.SetTrigger(Attack);

        [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();
    }
}