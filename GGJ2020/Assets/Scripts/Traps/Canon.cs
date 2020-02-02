using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] private GameObject target = null;
        [SerializeField] private GameObject bullet;
        [SerializeField] private float range = 50f;
        [SerializeField] private float rotationSpeed = 30.0f;
        [SerializeField] private Animator canonAnim;
        [SerializeField] private Manager.GameManager gameManager;
        private List<GameObject> enemies;
        private Quaternion m_lookRotation;
        private bool recovery;
        private float timer;
        private int cooldown;

        void Start()
        {
            enemies = gameManager.GetGolems();
        }

        void Update()
        {
            // Find target
            foreach (var enemy in enemies)
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) <= range)
                {
                    target = enemy.gameObject;
                    break;
                }
            }
            
            if (target != null && Vector3.Distance(transform.position, target.transform.position) <= range)
            {
                m_lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);

                if (transform.rotation != m_lookRotation)
                {
                    transform.rotation =
                        Quaternion.RotateTowards(transform.rotation, m_lookRotation,
                            rotationSpeed * Time.deltaTime * -1.0f);
                }

                if (!recovery)
                {
                    Shoot();
                    recovery = !recovery;
                }

                else if (recovery)
                {
                    timer += Time.deltaTime;
                    if (timer >= cooldown)
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
}