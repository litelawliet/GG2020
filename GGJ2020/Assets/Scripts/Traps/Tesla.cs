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
        private int HPmax;
        public GameObject particle;
        [SerializeField] private int damage = 2;


        private void Start()
        {
            HPmax = hp;
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

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Golem"))
            {
                particle.SetActive(false);
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