using Sources.Utils.Data;
using UnityEngine;

namespace Sources.Utils.Extensions
{
    public static class Vector3Extension
    {
        public static Vector3Data ToVector3Data(this Vector3 vector) =>
            new () { X = vector.x, Y = vector.y, Z = vector.z };

        public static Vector3 ToVector3(this Vector3Data vector3Data) =>
            new (vector3Data.X, vector3Data.Y, vector3Data.Z);
    }
}