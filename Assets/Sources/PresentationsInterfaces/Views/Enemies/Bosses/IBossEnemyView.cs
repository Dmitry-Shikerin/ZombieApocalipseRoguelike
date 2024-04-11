using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Enemies.Bosses
{
    public interface IBossEnemyView : IEnemyView, IView
    {
        // float StoppingDistance { get; }
        // Vector3 Position { get; }
        // ICharacterMovementView CharacterMovementView { get; }
        // ICharacterHealthView CharacterHealthView { get; }
        //
        // void Move(Vector3 direction);
        // void SetTargetFollow(ICharacterMovementView target);
        // void SetCharacterHealth(ICharacterHealthView characterHealthView);
        void PlayMassAttackParticle();
        void SetAgentSpeed(float speed);
    }
}