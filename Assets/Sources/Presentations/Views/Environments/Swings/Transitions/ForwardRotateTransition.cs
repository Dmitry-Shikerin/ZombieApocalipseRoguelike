using System;
using NodeCanvas.Framework;
using UnityEngine;

namespace Sources.Presentations.Views.Environments.Swings.Transitions
{
    public class ForwardRotateTransition : ConditionTask
    {
        private float _targetAngle;
        private Transform _transform;

        protected override string OnInit()
        {
            _transform = blackboard.GetVariable<Transform>("_transform").value;
            _targetAngle = 20;
            return null;
        }

        protected override void OnEnable()
        {
        }

        protected override void OnDisable()
        {
        }

        protected override bool OnCheck() =>
            Math.Abs(_targetAngle - _transform.rotation.eulerAngles.x) < 0.1f;
    }
}