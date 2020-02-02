using System.Collections;
using System.Collections.Generic;
using Manager;
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
        private bool recovery = false;
        private float timer;
        private int cooldown;

        void Start()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            enemies = gameManager.GetGolems();
        }

        void Update()
        {
            // Find target
            if (target == null)
            {
                foreach (GameObject enemy in enemies)
                {
                    if (Vector3.Distance(enemy.transform.position, transform.position) <= range)
                    {
                        if (enemy.activeSelf)
                        {
                            target = enemy.gameObject;

                            break;
                        }
                    }
                }
            }

            if (recovery)
            {
                timer += Time.deltaTime;
                if (timer >= cooldown)
                {
                    recovery = false;
                    timer = 0.0f;
                }
            }

            if (target != null)
            {
                m_lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                m_lookRotation.x = 0.0f;
                m_lookRotation.z = 0.0f;
                
                if (transform.rotation != m_lookRotation)
                {
                    transform.rotation =
                        Quaternion.RotateTowards(transform.rotation, m_lookRotation,
                            rotationSpeed * Time.deltaTime * -1.0f);
                }

                if (Mathf.Abs(transform.rotation.y - target.transform.rotation.y) <= 5.0f)
                {
                    if (!recovery)
                    {
                        Shoot();
                        recovery = true;
                    }
                }
            }

            //canonAnim.SetBool("Yeet", false);
        }

        private void Shoot()
        {
            canonAnim.SetBool("Yeet", true);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}