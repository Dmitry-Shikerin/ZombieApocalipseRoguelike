using UnityEngine;

namespace Sources.Infrastructure.Services.Characters
{
    public interface IEnemyIndicatorService
    {
        float GetAngleRotation(Vector3 from, Vector3 lookPosition);
    }
}