using System;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using Sources.Domain.Models.Constants;
using UnityEngine;

namespace Sources.Presentations.Views.Environments.Swings.Transitions
{
    [UsedImplicitly]
    public class BackwardRotateTransition : ConditionTask
    {
        private const float TargetAngle = 0;
        
        private Transform _transform;

        protected override string OnInit()
        {
            _transform = blackboard.GetVariableValue<Transform>("_transform");
            
            return null;
        }

        protected override bool OnCheck() =>
            Math.Abs(TargetAngle - _transform.rotation.eulerAngles.x) < MathConst.Epsilon;
    }
}