﻿using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using UnityEngine;

namespace Sources.Domain.Inputs
{
    public class InputData : IContext
    {
        public Vector3 MoveDirection { get; set; }
        public Vector3 LookPosition { get; set; }
        public float Speed { get; set; }
    }
}