using Sources.Domain.Models.Characters;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Characters
{
    public interface ICharacterMovementService
    {
        void SetSpeed(CharacterMovement characterMovement, float speed, float deltaTime);

        void SetDirection(CharacterMovement characterMovement, Vector3 movementDirection, float deltaTime);

        float GetAngleRotation(Vector3 characterPosition, Vector3 lookPosition);

        void SetAnimationDirection(
            CharacterMovement characterMovement, Vector3 movementDirection, float angleRotation, float deltaTime);
    }
}