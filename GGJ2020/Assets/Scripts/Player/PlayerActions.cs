using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private GameObject trapToDrop = null;
    [SerializeField] private float distanceToPick = 3.5f;

    private RaycastHit _hit;
    private Camera _camera;
    private bool _isHoldingGolemCore = false;

    private void Start()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (_camera != null)
        {
            Ray cameraToCursorRay = _camera.ScreenPointToRay(Input.mousePosition);

            //if(Debug.isDebugBuild)
                Debug.DrawRay(transform.position, cameraToCursorRay.direction * distanceToPick, Color.red);
            
            if (Physics.Raycast(transform.position, cameraToCursorRay.direction, out _hit,
                distanceToPick))
            {
                if (_hit.transform.tag.Equals("Pickable"))
                {
                    if (!_isHoldingGolemCore && Input.GetKeyDown(KeyCode.F))
                    {
                        trapToDrop = _hit.transform.gameObject;
                        _hit.transform.gameObject.SetActive(false);
                        _isHoldingGolemCore = true;
                    }
                }
                else if (_hit.transform.tag.Equals("Ground"))
                {
                    // We can put the core here and construct a trap
                    if (_isHoldingGolemCore && Input.GetKeyDown(KeyCode.F))
                    {
                        if (trapToDrop != null)
                        {
                            // Find hitpoint from where to place the trap
                            trapToDrop.transform.position = _hit.point;
                            trapToDrop.SetActive(true);
                        }

                        _isHoldingGolemCore = false;
                    }
                }
            }
            
        }
    }
}