using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyView
    {
        ICharacterMovementView CharacterMovementView { get; }
        
        void Move(Vector3 direction);
        void SetTargetFollow(ICharacterMovementView target);
        
    }
}