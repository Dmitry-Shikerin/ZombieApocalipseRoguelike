using System;
using Sources.InfrastructureInterfaces.Services.Bears;
using UnityEngine;

namespace Sources.Infrastructure.Services.Bears
{
    public class BearMovementService : IBearMovementService
    {
        public float GetAngleRotation(Vector3 enemyPosition, Vector3 bearPosition)
        {
            Vector3 lookDirection = enemyPosition - bearPosition;
            lookDirection.y = bearPosition.y;
            float distance = lookDirection.magnitude;
            
            if (distance < 0.7f)
                throw new InvalidOperationException(nameof(distance));
            
            return Vector3.SignedAngle(Vector3.forward, lookDirection, Vector3.up);
        }
    }
}