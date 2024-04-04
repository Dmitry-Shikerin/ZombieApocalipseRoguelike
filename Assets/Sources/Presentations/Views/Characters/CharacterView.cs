using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterView : View
    {
        [Required] [SerializeField] private CharacterMovementView _characterMovementView;
        [Required] [SerializeField] private CharacterAnimationView _characterAnimationView;
        
        public CharacterMovementView CharacterMovementView => _characterMovementView;
        public CharacterAnimationView CharacterAnimationView => _characterAnimationView;
    }
}