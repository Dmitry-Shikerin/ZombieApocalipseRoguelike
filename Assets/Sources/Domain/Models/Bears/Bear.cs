using System;
using Sources.Controllers.Bears.Attacks;
using UnityEngine;

namespace Sources.Domain.Models.Bears
{
    public class Bear
    {
        public BearAttacker BearAttacker { get; }

        public Bear(BearAttacker bearAttacker)
        {
            BearAttacker = bearAttacker ?? throw new ArgumentNullException(nameof(bearAttacker));
        }

        public Vector3 Position { get; set; }
    }
}