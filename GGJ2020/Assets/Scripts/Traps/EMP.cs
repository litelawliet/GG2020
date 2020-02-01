using System.Collections;
using Enemies;
using UnityEngine;

namespace Traps
{
    public class EMP : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle = null;
        [SerializeField] private Golem golemObject = null;
        [SerializeField] private uint freezeTime = 5u;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Golem"))
            {
                golemObject = other.GetComponent<Golem>();
                particle.Play();
                golemObject.GetNav().enabled = false;
                StartCoroutine(WaitForSec(freezeTime));
            }
        }

        IEnumerator WaitForSec(uint pSeconds)
        {
            yield return new WaitForSeconds(pSeconds);
            gameObject.SetActive(false);
            golemObject.GetNav().enabled = true;
        }
    }
}
