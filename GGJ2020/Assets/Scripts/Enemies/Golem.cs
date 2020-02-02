using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Golem : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private GameObject golemScrap;
        [SerializeField] private GameObject player = null;
        [SerializeField] private Animator golemAnim = null;
        [SerializeField] private GolemHitbox golemHitbox = null;

        private bool _triggered;
        private NavMeshAgent _golemNavMesh;

        void Start()
        {
            _golemNavMesh = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (!_triggered)
            {
                _golemNavMesh.speed = 6;
            }
            if (_golemNavMesh.isActiveAndEnabled)
            {
                _golemNavMesh.SetDestination(player.transform.position);
            }

            if (hp <= 0)
            {
                //Instantiate(golemScrap, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (_triggered)
            {
                _golemNavMesh.speed = 1;
                transform.LookAt(player.transform.position);
                golemAnim.SetTrigger("Attacc");
                _triggered = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                _triggered = true;
            }
        }

        public void ReduceHP()
        {
            if (golemHitbox.IsWallHit())
            {
                hp -= 2;
                golemHitbox.SetWallHit(false);
            }
            else
            {
                hp--;
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
