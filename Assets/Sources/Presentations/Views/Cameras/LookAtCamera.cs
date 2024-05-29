﻿using UnityEngine;

namespace Sources.Presentations.Views.Cameras
{
    public class LookAtCamera : View
    {
        private Camera _mainCamera;

        private void Start() =>
            _mainCamera = Camera.main;

        private void Update()
        {
            Quaternion rotation = _mainCamera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }
    }
}