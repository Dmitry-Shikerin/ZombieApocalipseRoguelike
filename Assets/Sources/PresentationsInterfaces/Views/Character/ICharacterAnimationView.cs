using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Character
{
    public interface ICharacterAnimationView
    {
        void PlayIdle();
        void PlayForward();
        void PlayBackward();
        void PlayLeftward();
        void PlayRightward();
        void PlayForwardRight();
        void PlayForwardLeft();
        void PlayBackwardRight();
        void PlayBackwardLeft();
        void SetDirection(Vector2 position);
    }
}