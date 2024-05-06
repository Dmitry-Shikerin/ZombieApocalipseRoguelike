using System;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{
    public class BackwardRotateTransition : ConditionTask
    {
        private float _currentAngle;
        private float _targetAngle;
        private Transform _transform;

        protected override string OnInit()
        {
            _transform = blackboard.GetVariable<Transform>("_transform").value;
            _targetAngle = 0;
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