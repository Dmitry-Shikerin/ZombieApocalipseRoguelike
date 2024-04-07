using System;
using Sources.Domain.Inputs;
using Sources.InfrastructureInterfaces.Services.InputServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Infrastructure.Services.InputServices
{
    public class NewInputService : IInputService, IInputServiceUpdater
    {
        private InputManager _inputManager;
        private float _speed;

        public NewInputService()
        {
            _inputManager = new InputManager();
            _inputManager.Enable();
            InputData = new InputData();

            //TODO сделать отписку
            _inputManager.Gameplay.Attack.performed += OnAttack;
        }
        
        public event Action Attacked;

        private void OnAttack(InputAction.CallbackContext obj)
        {
            Attacked?.Invoke();
        }

        public InputData InputData { get; }

        public void Update(float deltaTime)
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            Vector2 input = _inputManager.Gameplay.Movement.ReadValue<Vector2>();
            float speed = _inputManager.Gameplay.Run.ReadValue<float>();
            
            Vector3 lookDirection = Vector3.zero;
            
            if (TryGetLook(out Vector3 look))
                lookDirection = look;

            InputData.MoveDirection = new Vector3(input.x, 0, input.y);
            InputData.LookPosition = lookDirection;
            InputData.Speed = speed;
        }
        
        private bool TryGetLook(out Vector3 lookDirection)
        {
            lookDirection = Vector3.zero;
            Ray cameraPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraPosition,
                    out RaycastHit raycastHit, float.MaxValue, 1 << LayerMask.NameToLayer("Plane")) == false)
                return false;

            lookDirection = raycastHit.point;
            return true;
        }
    }
}