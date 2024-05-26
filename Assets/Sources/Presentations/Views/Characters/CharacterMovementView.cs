using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Characters.Movements;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterMovementView : PresentableView<CharacterMovementPresenter>, ICharacterMovementView
    {
        [Required] [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _maxDegreesRotationDelta = 11f;

        public Vector3 Position => transform.position;
        
        public void SetLookRotation(float angle)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.Euler(0, angle, 0), _maxDegreesRotationDelta);
        }

        public void Move(Vector3 direction) =>
            _characterController.Move(direction);
    }
}