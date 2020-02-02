using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float range = 50f;
    [SerializeField] private Animator canonAnim;
    [SerializeField] private Manager.GameManager gameManager;
    private bool recovery;
    private float timer;
    private int cooldown;

    void Start()
    {
        
    }

    void Update()
    {
        gameManager.GetGolems();


        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= range)
        {
            float angle = Vector3.Angle(transform.position, target.transform.position);
            transform.Rotate(Vector3.up, angle);
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
