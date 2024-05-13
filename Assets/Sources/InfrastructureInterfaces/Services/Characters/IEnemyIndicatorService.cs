using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Characters
{
    public interface IEnemyIndicatorService
    {
        float GetAngleRotation(Vector3 from, Vector3 lookPosition);
    }
}