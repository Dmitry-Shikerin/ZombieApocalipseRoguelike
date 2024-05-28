using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Enemies
{
    public interface IEnemyAttackService
    {
        void TryAttack(Vector3 position, int damage);
    }
}