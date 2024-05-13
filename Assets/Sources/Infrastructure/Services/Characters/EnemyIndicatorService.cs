using Sources.InfrastructureInterfaces.Services.Characters;
using UnityEngine;

namespace Sources.Infrastructure.Services.Characters
{
    public class EnemyIndicatorService : IEnemyIndicatorService
    {
        public float GetAngleRotation(Vector3 from, Vector3 lookPosition)
        {
            Vector3 lookDirection = lookPosition - from;
            lookDirection.y = from.y;

            return Vector3.SignedAngle(Vector3.forward, lookDirection, Vector3.up);
        }
    }
}