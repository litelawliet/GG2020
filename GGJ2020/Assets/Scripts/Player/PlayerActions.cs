using System.Collections.Generic;
using Manager;
using UnityEngine;
using UnityEngine.XR;

namespace Player
{
    public class PlayerActions : MonoBehaviour
    {
        [SerializeField] private GameObject trapToDrop = null;
        [SerializeField] private float distanceToPick = 3.5f;
        [SerializeField] private GameManager manager = null;
        [SerializeField] private float pushRange = 10.0f;
        [SerializeField] private float pushForce = 1.0f;

        private RaycastHit _hit;
        private Camera _camera;
        private bool _isHoldingGolemCore = false;
        private bool _isInPreview = false;

        private bool _usePressed = false;
        private bool _leftClickPressed = false;
        private bool _rightClickPressed = false;
        private bool _raycastExist = false;

        List<GameObject> inRangeGolems = new List<GameObject>();


        private void Start()
        {
            _camera = GetComponentInChildren<Camera>();
            manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F))
                _usePressed = false;
            else if (Input.GetKeyDown(KeyCode.F))
                _usePressed = true;

            if (Input.GetMouseButtonUp(0))
                _leftClickPressed = false;
            else if (Input.GetMouseButtonDown(0))
                _leftClickPressed = true;

            if (Input.GetMouseButtonUp(1))
                _rightClickPressed = false;
            else if (Input.GetMouseButtonDown(1))
                _rightClickPressed = true;

            if (_raycastExist)
            {
                if (_hit.transform.gameObject.CompareTag("Pickable"))
                {
                    if (_usePressed)
                    {
                        if (!_isHoldingGolemCore)
                        {
                            trapToDrop = _hit.transform.gameObject;
                            _hit.transform.gameObject.SetActive(false);
                            _isHoldingGolemCore = true;
                        }

                        if (_isInPreview && _isHoldingGolemCore)
                        {
                            _hit.transform.gameObject.SetActive(false);
                            _isInPreview = false;
                        }
                    }

                    if (_leftClickPressed && _isHoldingGolemCore && _isInPreview)
                    {
                        trapToDrop.transform.position = _hit.point;
                        _isInPreview = false;
                        _isHoldingGolemCore = false;
                        trapToDrop = null;
                    }
                }

                if (_hit.transform.gameObject.CompareTag("Ground"))
                {
                    if (trapToDrop != null)
                        trapToDrop.transform.position = _hit.point;

                    if (_usePressed)
                    {
                        if (_isHoldingGolemCore)
                        {
                            if (trapToDrop != null)
                                trapToDrop.SetActive(true);
                            _isInPreview = true;
                        }
                    }

                    if (_leftClickPressed)
                    {
                        if (_isInPreview)
                        {
                            _isInPreview = false;
                            _isHoldingGolemCore = false;
                        }
                    }
                }
            }

            // We can "fight", we're not in construction and placement mode
            if (_isInPreview)
            {
                if (_leftClickPressed)
                {
                    // Attack
                }
                else if (_rightClickPressed)
                {
                    // Push enemies
                    // Find golems inside the range of push
                    float distance = float.MaxValue;
                    if (inRangeGolems.Count == 0)
                    {
                        foreach (GameObject golem in manager.GetGolems())
                        {
                            distance = Vector3.Distance(transform.position, golem.transform.position);
                            if (distance <= pushRange)
                            {
                                inRangeGolems.Add(golem);
                                golem.GetComponent<Rigidbody>().AddForce(golem.transform.forward * (pushForce * -100.0f));

                            }
                        }
                    }

                    manager.GetGolems();
                }
            }
        }

        private void FixedUpdate()
        {
            if (_camera != null)
            {
                Ray cameraToCursorRay = _camera.ScreenPointToRay(Input.mousePosition);

                Debug.DrawRay(transform.position, cameraToCursorRay.direction * distanceToPick, Color.red);

                _raycastExist = Physics.Raycast(transform.position, cameraToCursorRay.direction, out _hit,
                    distanceToPick);
            }

            inRangeGolems.Clear();
        }
    }
}