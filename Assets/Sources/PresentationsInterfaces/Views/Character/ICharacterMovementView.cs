using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Character
{
    public interface ICharacterMovementView
    {
        Vector3 Position { get; }
        
        void SetLookRotation(float angle);
        void Move(Vector3 direction);
    }
}