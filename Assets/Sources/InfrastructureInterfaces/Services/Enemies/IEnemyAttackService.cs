using UnityEngine;

namespace Sources.Infrastructure.Services.Enemies
{
    public interface IEnemyAttackService
    {
        void TryAttack(Vector3 position, int damage);
    }
}