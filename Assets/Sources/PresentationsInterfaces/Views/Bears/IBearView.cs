
using Sources.Presentations.Views.Bears;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Bears
{
    public interface IBearView
    {
        BearAnimationView BearAnimationView { get; }
        Vector3 Position { get; }
        Vector3 Forward { get; }
        float StoppingDistance { get; }
        IEnemyHealthView TargetEnemyHealth { get; }
        ICharacterMovementView CharacterMovementView { get; }

        void Move(Vector3 position);
        void SetTarget(IEnemyHealthView enemyHealthView);
        void SetTargetFollow(ICharacterMovementView characterMovementView);
        void SetStoppingDistance(float stoppingDistance);
        void SetLookRotation(float angle);
    }
}