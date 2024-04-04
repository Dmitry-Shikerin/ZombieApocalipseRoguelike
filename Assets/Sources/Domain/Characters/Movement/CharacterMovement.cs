using Sources.Domain.Common;
using UnityEngine;

namespace Sources.Domain.Characters.Movement
{
    public class CharacterMovement : ObservableModel
    {
        private Vector3 _direction;

        public Vector3 Direction
        {
            get => _direction;
            set => SetField(ref _direction, value);
        }
    }
}