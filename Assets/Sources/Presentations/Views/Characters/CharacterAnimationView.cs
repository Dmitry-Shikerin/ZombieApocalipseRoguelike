using Sirenix.OdinInspector;
using Sources.Presentations.Views.Animations;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterAnimationView : AnimationViewBase, ICharacterAnimationView
    {
        [Required] [SerializeField] private Animator _animator;

        private static int s_positionX = Animator.StringToHash("PositionX");
        private static int s_positionZ = Animator.StringToHash("PositionZ");
        
        public void SetDirection(Vector2 position)
        {
            _animator.SetFloat(s_positionX, position.x);
            _animator.SetFloat(s_positionZ, position.y);
        }
    }
}