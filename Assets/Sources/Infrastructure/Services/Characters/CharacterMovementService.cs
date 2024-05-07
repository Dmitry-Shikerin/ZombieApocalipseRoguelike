using System;
using Sources.Domain.Models.Characters;
using Sources.InfrastructureInterfaces.Characters;
using UnityEngine;

namespace Sources.Infrastructure.Services.Characters
{
    public class CharacterMovementService : ICharacterMovementService
    {
        private const float Delta = 1;
        private const float Scalar = 2;
        
        public void SetSpeed(CharacterMovement characterMovement, float speed, float deltaTime)
        {
            characterMovement.Speed = Mathf.MoveTowards(
                characterMovement.Speed, speed, Delta * deltaTime);
        }

        public void SetDirection(CharacterMovement characterMovement, Vector3 movementDirection,  float deltaTime)
        {
            characterMovement.Direction = characterMovement.Speed * Scalar *
                                           deltaTime *
                                           movementDirection.normalized +
                                           Physics.gravity;
        }

        public float GetAngleRotation(Vector3 characterPosition, Vector3 lookPosition)
        {
            Vector3 lookDirection = lookPosition - characterPosition;
            lookDirection.y = characterPosition.y;
            float distance = lookDirection.magnitude;

            if (distance < 0.7f)
                throw new InvalidOperationException(nameof(distance));

            return Vector3.SignedAngle(Vector3.forward, lookDirection, Vector3.up);
        }

        public void SetAnimationDirection(
            CharacterMovement characterMovement, 
            Vector3 movementDirection, 
            float angleRotation, 
            float deltaTime)
        {
            Vector3 direction = Quaternion.Euler(0, -angleRotation, 0) * movementDirection;

            Vector2 direction2 = new Vector2(direction.x, direction.z).normalized;
            characterMovement.AnimationDirection =
                Vector2.MoveTowards(
                    characterMovement.AnimationDirection,
                    direction2,
                    characterMovement.AnimationDirectionSpeed * deltaTime);
        }
    }
}