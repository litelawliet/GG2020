using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private float jumpHeight = 3.0f;
    [SerializeField] float speed = 12.0f;
    [SerializeField] private float groundDistance = 0.4f;
    
    public LayerMask groundMask;

    private Transform _playerTransform;
    private Vector3 _velocity;
    private const float Gravity = -9.80665f;
    private bool _isGrounded;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        _playerTransform = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2.0f;
        }

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = _playerTransform.right * x + _playerTransform.forward * z;
        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * Gravity);
        }

        _velocity.y += Gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }
}