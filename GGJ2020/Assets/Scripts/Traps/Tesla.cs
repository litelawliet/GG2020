using Enemies;
using UnityEngine;

namespace Traps
{
    public class Tesla : MonoBehaviour
    {
        public SphereCollider aoeRadius;
        public GameObject golem;
        [SerializeField] private GameObject breakDown;
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
                breakDown.SetActive(true);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (hp > 0 && other.CompareTag("Golem"))
            {
                golem = other.gameObject;
                golemScript = golem.GetComponent<Golem>();

                Tazzing();
                particle.transform.LookAt(golem.transform.position);
            }
           
        }

        private void Tazzing()
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                particle.SetActive(true);
                Attack();
                timer = 0;
            }
        }

        public void Attack()
        {
            golemScript.ReduceHP(damage);
            Debug.Log(hp);
        }

        public void Heal(int p_HealValue)
        {
            hp += p_HealValue;
        }
    }

    
}