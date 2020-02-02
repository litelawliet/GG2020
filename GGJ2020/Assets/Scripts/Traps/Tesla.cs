using Enemies;
using UnityEngine;

namespace Traps
{
    public class Tesla : MonoBehaviour
    {
        public SphereCollider aoeRadius;
        public GameObject golem;
        public Golem golemScript;

        public int hp;
        float timer;
        public int cooldown;
        public GameObject particle;
        [SerializeField] private int damage = 2;

        void Update()
        {
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Golem"))
            {
                golem = other.gameObject;
                golemScript = golem.GetComponent<Golem>();

                Tazzing();
            }
        }

        private void Tazzing()
        {
            
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                particle.SetActive(true);
                particle.transform.LookAt(golem.transform.position);
                Attack();
                timer = 0;
            }
        }

        public void Attack()
        {
            golemScript.ReduceHP(damage);
            Debug.Log(hp);
        }
    }
}