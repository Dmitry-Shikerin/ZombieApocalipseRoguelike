using UnityEngine;

namespace Sources.Controllers.LayerMasks
{
    public static class Layer
    {
        public static readonly int Default = 0;
        public static readonly int Plane = 1 << LayerMask.NameToLayer("Plane");
        public static readonly int Enemy = 1 << LayerMask.NameToLayer("Enemy");
    }
}