using UnityEngine;

namespace Enemies
{
    public class GolemHitbox : MonoBehaviour
    {
        [SerializeField] private bool wallHit;
        [SerializeField] private Golem golemScript;

        private void Start()
        {
            golemScript = GetComponentInParent<Golem>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            wallHit = false;
            if (collider.gameObject.CompareTag("Player"))
            {
            }
            else if (collider.gameObject.CompareTag("Environment"))
            {
                wallHit = true;
                golemScript.ReduceHP();
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