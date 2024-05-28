using System;
using Sources.Domain.Models.Bears.Attacks;
using UnityEngine;

namespace Sources.Domain.Models.Bears
{
    public class Bear
    {
        public Bear(BearAttacker bearAttacker)
        {
            BearAttacker = bearAttacker ?? throw new ArgumentNullException(nameof(bearAttacker));
        }
        
        public BearAttacker BearAttacker { get; }
        public Vector3 Position { get; set; }
    }
}