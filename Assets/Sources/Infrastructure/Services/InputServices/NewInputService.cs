﻿using System;
using Sources.Domain.Models.Constants.LayerMasks;
using Sources.Domain.Models.Inputs;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using UnityEngine;

namespace Sources.Infrastructure.Services.InputServices
{
    public class NewInputService : IInputService, IInputServiceUpdater
    {
        private readonly IPauseService _pauseService;
        private InputManager _inputManager;
        private float _speed;

        public NewInputService(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
            _inputManager = new InputManager();
            InputData = new InputData();
            
            _inputManager.Enable();
        }
        
        public InputData InputData { get; }

        public void Update(float deltaTime)
        {
            if(_pauseService.IsPaused)
                return;
            
            UpdateMovement();
            UpdateAttack();
        }

        private void UpdateAttack() =>
            InputData.IsAttacking = _inputManager.Gameplay.Attack.IsPressed();

        private void UpdateMovement()
        {
            Vector2 input = _inputManager.Gameplay.Movement.ReadValue<Vector2>();
            float speed = _inputManager.Gameplay.Run.ReadValue<float>();
            
            Vector3 lookDirection = Vector3.zero;
            
            if (TryGetLook(out Vector3 look))
                lookDirection = look;

            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0;
            
            float angle = Vector3.SignedAngle(Vector3.forward, cameraForward, Vector3.up);
            Vector3 moveDirection = Quaternion.Euler(0, angle, 0) * new Vector3(input.x, 0, input.y);
            
            InputData.MoveDirection =  moveDirection;
            InputData.LookPosition = lookDirection;
            InputData.Speed = speed;
        }
        
        private bool TryGetLook(out Vector3 lookDirection)
        {
            lookDirection = Vector3.zero;
            Ray cameraPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraPosition,
                    out RaycastHit raycastHit, float.MaxValue, Layer.Plane) == false)
                return false;

            lookDirection = raycastHit.point;
            return true;
        }
    }
}