using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyView : IView
    {
        float StoppingDistance { get; }
        Vector3 Position { get; }
        ICharacterMovementView CharacterMovementView { get; }
        ICharacterHealthView CharacterHealthView { get; }
        
        void Move(Vector3 direction);
        void SetTargetFollow(ICharacterMovementView target);
        void SetCharacterHealth(ICharacterHealthView characterHealthView);
    }
}