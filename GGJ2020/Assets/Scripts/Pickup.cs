using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Vector3 objectPosition;
    private float distance = 0.0f;
    public float holdingDistance = 2.5f;

    public bool canHold = true;
    private GameObject item = null;
    public GameObject tempParent;

    public bool isHolding = false;
    private Rigidbody _rigidbody;

    private void Start()
    {
        item = gameObject;
        _rigidbody = item.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance >= holdingDistance)
        {
            isHolding = false;
        }

        if (distance <= holdingDistance)
        {
            if (isHolding && Input.GetKeyDown(KeyCode.F))
            {
                isHolding = true;
                
            }
        }

        if (isHolding)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetKeyDown(KeyCode.F))
            {
                isHolding = false;
                _rigidbody.useGravity = true;
                item.transform.SetParent(null);
            }
        }
        else
        {
            objectPosition = item.transform.position;
            item.transform.SetParent(null);
            _rigidbody.useGravity = true;
            item.transform.position = objectPosition;
        }
    }

    private void OnMouseDown()
    {
    }

    private void OnMouseUp()
    {
        isHolding = false;
    }
}