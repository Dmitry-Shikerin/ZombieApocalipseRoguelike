﻿using System;
using JetBrains.Annotations;
using Sources.Presentations.Views.Animations;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies.Base
{
    public class EnemyAnimation : AnimationViewBase, IEnemyAnimation
    {
        private static int s_isIdle = Animator.StringToHash("IsIdle");
        private static int s_isWalk = Animator.StringToHash("IsWalk");
        private static int s_isAttack = Animator.StringToHash("IsAttack");

        public event Action Attacking;

        private void Awake()
        {
            StoppingAnimations.Add(StopIdle);
            StoppingAnimations.Add(StopAttack);
            StoppingAnimations.Add(StopWalk);
            OnAfterAwake();
        }

        public void PlayWalk()
        {
            ExceptAnimation(StopWalk);
            Animator.SetBool(s_isWalk, true);
        }

        public void PlayIdle()
        {
            ExceptAnimation(StopIdle);
            Animator.SetBool(s_isIdle, true);
        }

        public void PlayAttack()
        {
            ExceptAnimation(StopAttack);
            Animator.SetBool(s_isAttack, true);
        }

        protected virtual void OnAfterAwake()
        {
        }

        [UsedImplicitly]
        private void OnAttack() =>
            Attacking?.Invoke();

        private void StopWalk()
        {
            if (Animator.GetBool(s_isWalk) == false)
                return;

            Animator.SetBool(s_isWalk, false);
        }

        private void StopIdle()
        {
            if (Animator.GetBool(s_isIdle) == false)
                return;

            Animator.SetBool(s_isIdle, false);
        }

        private void StopAttack()
        {
            if (Animator.GetBool(s_isAttack) == false)
                return;

            Animator.SetBool(s_isAttack, false);
        }
    }
}