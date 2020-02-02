using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Golem : MonoBehaviour
    {
        [SerializeField] private int hp = 5;
        [SerializeField] private GameObject golemScrap;
        private GameObject player = null;
        private GolemHitbox golemHitbox = null;
        
        
        private bool _triggered;
        private Animator golemAnim;

        private bool _wallHit;
        private NavMeshAgent _golemNavMesh;
        private float distanceMinForAttack = 7.0f;

        void Start()
        {
            _golemNavMesh = GetComponent<NavMeshAgent>();
            golemAnim = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player");
            golemHitbox = GetComponentInChildren<GolemHitbox>();
            _golemNavMesh.Warp(transform.position);
        }

        void Update()
        {
            if (_golemNavMesh.isActiveAndEnabled)
            {
                _golemNavMesh.SetDestination(player.transform.position);
            }

            if (hp <= 0)
            {
                //Instantiate(golemScrap, transform.position, Quaternion.identity);
                GolemDeath();
            }

            if (_triggered)
            {
                transform.LookAt(player.transform.position);
                _triggered = false;
            }
        }

        private void GolemDeath()
        {
            gameObject.SetActive(false);
            Instantiate(golemScrap, transform.position, Quaternion.identity);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {}
            else if (other.CompareTag("Player"))
            {
                _triggered = true;
                golemAnim.SetBool("Attacc", true);
            }
            else if (other.CompareTag("Environment"))
            {
                _wallHit = true;
                ReduceHP();
            }
            else if (other.CompareTag("Ammo"))
            {
                GolemDeath();
            }
        }

        public void ReduceHP()
        {
            if (_wallHit)
            {
                hp -= 2;
                _wallHit = false;
                Debug.Log(hp);
            }
            else
            {
                hp--;
                Debug.Log(hp);
            }
        }

        public void ReduceHP(int p_damage)
        {
            hp -= p_damage;    
        }


        public NavMeshAgent GetNav()
        {
            return _golemNavMesh;
        }
    }
}
