using System.Collections;
using Enemies;
using UnityEngine;

namespace Traps
{
    public class EMP : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle = null;
        [SerializeField] private uint freezeTime = 5u;
        private Golem _golemObject = null;
    
        private void OnTrigger(Collider other)
        {
            if (other.CompareTag("Golem"))
            {
                Debug.Log("Find golem on EPM");
                _golemObject = other.GetComponent<Golem>();
                particle.Play();
                _golemObject.GetNav().enabled = false;
                StartCoroutine(WaitForSec(freezeTime));
            }
        }

        IEnumerator WaitForSec(uint pSeconds)
        {
            yield return new WaitForSeconds(pSeconds);
            _golemObject.GetNav().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
