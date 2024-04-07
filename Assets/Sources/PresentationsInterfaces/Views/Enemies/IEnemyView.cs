using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyView
    {
        float StoppingDistance { get; }
        Vector3 Position { get; }
        ICharacterMovementView CharacterMovementView { get; }
        
        void Move(Vector3 direction);
        void SetTargetFollow(ICharacterMovementView target);
        
    }
}