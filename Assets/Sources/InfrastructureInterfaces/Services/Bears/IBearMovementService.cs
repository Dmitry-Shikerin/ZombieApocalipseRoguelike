using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Bears
{
    public interface IBearMovementService
    {
        float GetAngleRotation(Vector3 enemyPosition, Vector3 bearPosition);
    }
}