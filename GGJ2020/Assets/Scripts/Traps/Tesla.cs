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
        public ParticleSystem particle;
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
                Tazzing();
            }
        }

        private void Tazzing()
        {
            Vector3 direction = transform.position - golem.transform.position; // se servir de ce vecteur pour particule ?
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                //Instantiate tazzing particle using direction + direction.magnitude
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
