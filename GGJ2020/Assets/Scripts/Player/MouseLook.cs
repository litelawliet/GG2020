﻿using UnityEngine;

namespace Player
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField]
        private float mouseSensitivity = 100.0f;

        [SerializeField]
        private Transform playerBody = null;

        [SerializeField] private Texture2D mouseCursorTexture = null;
        [SerializeField] private CursorMode cursorMode = CursorMode.Auto;
        private Vector2 _hotSpot = Vector2.zero;
    
        private float xRotation = 0.0f;
    
        // Start is called before the first frame update
        void Start()
        {
            Cursor.SetCursor(mouseCursorTexture, _hotSpot, cursorMode);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
        
            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
