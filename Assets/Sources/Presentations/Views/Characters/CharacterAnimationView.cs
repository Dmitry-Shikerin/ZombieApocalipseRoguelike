using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterAnimationView : View, ICharacterAnimationView
    {
        [Required] [SerializeField] private Animator _animator;
        
        public void PlayIdle() =>
            _animator.Play("Idle");

        public void PlayForward() =>
            _animator.Play("Forward");

        public void PlayBackward() =>
            _animator.Play("Backward");

        public void PlayLeftward() =>
            _animator.Play("Leftward");

        public void PlayRightward() =>
            _animator.Play("Rightward");

        public void PlayForwardRight() =>
            _animator.Play("ForwardRight");

        public void PlayForwardLeft() =>
            _animator.Play("ForwardLeft");

        public void PlayBackwardRight() =>
            _animator.Play("BackwardRight");

        public void PlayBackwardLeft() =>
            _animator.Play("BackwardLeft");
    }
}