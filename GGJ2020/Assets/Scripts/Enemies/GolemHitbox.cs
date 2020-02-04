using UnityEngine;
using Traps;

namespace Enemies
{
    public class GolemHitbox : MonoBehaviour
    {
        [SerializeField] private bool wallHit;
        [SerializeField] private Golem golemScript;
        [SerializeField] private Player.PlayerHP playerHP;
        [SerializeField] private Canon canon;
        [SerializeField] private Tesla tesla;



        private void Start()
        {
            golemScript = GetComponentInParent<Golem>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            wallHit = false;

            if (collider.gameObject.CompareTag("Player"))
            {
                playerHP.ReduceLifeOf(1);
            }
            else if (collider.gameObject.CompareTag("Environment"))
            {
                wallHit = true;
                golemScript.ReduceHP();
            }
            else if (collider.CompareTag("Canon"))
            {
                golemScript.ReduceHP();
                canon.ReduceHp(1);
                Debug.Log("hp canon" + canon.GetHP());
            }
            else if (collider.CompareTag("Tesla"))
            {
                golemScript.ReduceHP();
                canon.ReduceHp(1);
                Debug.Log("Hp tesla" + tesla.GetHP());
            }
            else
            {
                golemScript.ReduceHP();
            }


        }

        public bool IsWallHit()
        {
            return wallHit;
        }

        public void SetWallHit(bool pWallHit)
        {
            wallHit = pWallHit;
        }
    }
}