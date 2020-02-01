using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float range = 50f;

    void Start()
    {
        
    }

    void Update()
    {
        


        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= range)
        {
            float angle = Vector3.Angle(transform.position, target.transform.position);
            transform.Rotate(Vector3.up, angle);
            Shoot();
        }
    }

    private void Shoot()
    {

    }

}
