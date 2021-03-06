﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Manager;
using UnityEngine;

namespace Traps
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] private GameObject target = null;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float range = 50f;
        [SerializeField] private float rotationSpeed = 30.0f;
        [SerializeField] private Animator canonAnim;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private float cooldown = 2.0f;
        [SerializeField] private float bulletSpeed = 100.0f;
        private List<GameObject> _enemies;
        private Quaternion _mLookRotation;
        [SerializeField] private GameObject breakDown;
        [SerializeField] private int hp;
        private bool _recovery = false;
        private float _timer;
        private int HPmax;

        void Start()
        {
            HPmax = hp;
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            _enemies = gameManager.GetGolems();
        }

        void Update()
        {
            if (hp >= HPmax)
            {
                hp = HPmax;
            }

            if (hp <= 0)
            {
                breakDown.SetActive(true);
            }
            // Find target
            else
            {
                if (target == null)
                {
                    foreach (GameObject enemy in _enemies)
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

                if (target != null && target.gameObject.activeSelf == false)
                    target = null;

                if (_recovery)
                {
                    _timer += Time.deltaTime;
                    if (_timer >= cooldown)
                    {
                        _recovery = false;
                        _timer = 0.0f;
                    }
                }

                if (target != null)
                {
                    _mLookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                    _mLookRotation.x = 0.0f;
                    _mLookRotation.z = 0.0f;

                    if (transform.rotation != _mLookRotation)
                    {
                        transform.rotation =
                            Quaternion.RotateTowards(transform.rotation, _mLookRotation,
                                rotationSpeed * Time.deltaTime * -1.0f);
                    }

                    if (!_recovery)
                    {
                        Shoot();
                        _recovery = true;
                    }
                }

            }
        }

        private void Shoot()
        {
            canonAnim.SetBool("Yeet", true);
            Vector3 positionBuller = transform.GetChild(1).position;
            GameObject bullet = Instantiate(bulletPrefab, positionBuller,
                transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(-bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
        }

        public void ReduceHp(int p_damage)
        {
            hp -= p_damage;

        }

        public int GetHP()
        {
            return hp;
        }

        public void Heal(int p_HealValue)
        {
            hp += p_HealValue;
        }
    }
}