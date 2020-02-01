using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float range = 50f;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private Animator canonAnim;
    [SerializeField] private Manager.GameManager gameManager;
    private Quaternion m_lookRotation;
    private bool recovery;
    private float timer;
    private int cooldown;

    void Start()
    {
        
    }

    void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= range)
        {
            m_lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);

            if (transform.rotation != m_lookRotation)
            {
                transform.rotation =
                    Quaternion.RotateTowards(transform.rotation, m_lookRotation, rotationSpeed * Time.deltaTime);
            }
            if (!recovery)
            {
                Shoot();
                recovery = !recovery;
            }

            else if (recovery)
            {
                timer += Time.deltaTime;
                if(timer >= cooldown)
                {
                    recovery = !recovery;
                    timer = 0;
                }
            }

        }
    }

    private void Shoot()
    {
        canonAnim.SetTrigger("Yeet");
        Instantiate(bullet, transform.position, Quaternion.identity);
        

    }

}
