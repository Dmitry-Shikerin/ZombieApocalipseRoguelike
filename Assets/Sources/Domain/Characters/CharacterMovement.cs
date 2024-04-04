using Sources.Domain.Common;
using UnityEngine;

namespace Sources.Domain.Characters
{
    public class CharacterMovement : ObservableModel
    {
        private Vector3 _direction;
        private float _speed;

        public Vector3 Direction
        {
            get => _direction;
            set => SetField(ref _direction, value);
        }

        public float Speed
        {
            get => _speed;
            set => SetField(ref _speed, value);
        }
    }
}