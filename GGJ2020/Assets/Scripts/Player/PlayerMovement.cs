﻿using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform groundCheck = null;
        [SerializeField] private float jumpHeight = 3.0f;
        [SerializeField] private float walkingSpeed = 6.0f;
        [SerializeField] private float sprintSpeedVertical = 12.0f;
        [SerializeField] private float sprintSpeedHorizontal = 9.0f;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private float initialFOV = 60.0f;
        [SerializeField] private float sprintingFOV = 30.0f;
        [SerializeField] [Range(10.0f, 20.0f)] private float fovSpeed = 10.0f;
        [SerializeField] private float fovCoefficientToOriginal;
  

        public LayerMask groundMask;

        private CharacterController controller;
        private Transform _playerTransform;
        private Vector3 _velocity;
        private const float Gravity = -9.80665f;
        private bool _isGrounded;
        private Vector3 _speed = Vector3.zero;
        private Camera _camera;
        private bool _isSprinting = false;
        private float _fovValue = 0.0f;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            _playerTransform = transform;
            _speed = new Vector3(walkingSpeed, 0.0f, walkingSpeed);
            _camera = GetComponentInChildren<Camera>();
        }

        private void Update()
        {
            _fovValue = fovSpeed * Time.deltaTime;
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2.0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _isSprinting = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _isSprinting = false;
                _speed = new Vector3(sprintSpeedHorizontal, 0.0f, sprintSpeedVertical);
            }

            Vector3 move = _playerTransform.right * x + _playerTransform.forward * z;
            move.x *= sprintSpeedHorizontal * Time.deltaTime;
            move.z *= sprintSpeedVertical * Time.deltaTime;
            
            controller.Move(move);

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * Gravity);
            }

            _velocity.y += Gravity * Time.deltaTime;

            controller.Move(_velocity * Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (_isSprinting)
            {
                if (_camera.fieldOfView < sprintingFOV)
                    _camera.fieldOfView = sprintingFOV;
                else if (_camera.fieldOfView > sprintingFOV)
                    _camera.fieldOfView -= _fovValue;
            }
            else
            {
                if (_camera.fieldOfView > initialFOV)
                    ResetFOV();
                else if (_camera.fieldOfView < initialFOV)
                {
                    fovCoefficientToOriginal = 4.0f;
                    _camera.fieldOfView += _fovValue * fovCoefficientToOriginal;
                }
            }
        }


        public bool IsGrounded()
        {
            return _isGrounded;
        }
        public void ResetFOV()
        {
            _camera.fieldOfView = initialFOV;
        }

   
    }
}