using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float range = 50f;
<<<<<<< Updated upstream
    [SerializeField] private float canonSpeed = 10.0f;
    [SerializeField] private Animator canonAnim;
    [SerializeField] private Manager.GameManager gameManager;

    private Quaternion m_lookRotation;
    private Vector3 m_lastKnownPosition = Vector3.zero;
=======
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private Animator canonAnim;
    [SerializeField] private Manager.GameManager gameManager;
    private Quaternion m_lookRotation;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            if (m_lastKnownPosition != target.transform.position)
            {
                m_lastKnownPosition = target.transform.position;
                m_lookRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            }
=======
            m_lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
>>>>>>> Stashed changes

            if (transform.rotation != m_lookRotation)
            {
                transform.rotation =
<<<<<<< Updated upstream
                    Quaternion.RotateTowards(transform.rotation, m_lookRotation, canonSpeed * Time.deltaTime);
            }

            //float angle = Vector3.Angle(transform.position, target.transform.position);
            //ransform.RotateAround(transform.position, Vector3.up, angle);
=======
                    Quaternion.RotateTowards(transform.rotation, m_lookRotation, rotationSpeed * Time.deltaTime);
            }
>>>>>>> Stashed changes
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
