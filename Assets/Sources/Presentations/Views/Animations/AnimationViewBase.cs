using System;
using System.Collections.Generic;

namespace Sources.Presentations.Views.Animations
{
    public abstract class AnimationViewBase : View
    {
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