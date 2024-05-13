﻿using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.Views.Animations
{
    public abstract class AnimationViewBase : View
    {
        [Required] [SerializeField] private Animator _animator;
        
        protected Animator Animator => _animator;
        
        protected  List<Action> StoppingAnimations { get; private set; } = new List<Action>();
        
        protected void ExceptAnimation(Action exceptAnimation)
        {
            foreach (Action animation in StoppingAnimations)
            {
                if(animation == exceptAnimation)
                    continue;
                
                animation.Invoke();
            }
        }
    }
}