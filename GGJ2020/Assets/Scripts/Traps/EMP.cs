using System.Collections;
using Enemies;
using UnityEngine;

namespace Traps
{
    public class EMP : MonoBehaviour
    {
        [SerializeField] private GameObject particle;
        [SerializeField] private uint freezeTime = 5u;
        private Golem _golemObject = null;
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Golem"))
            {
                Debug.Log("Find golem on EMP");
                particle.SetActive(true);
                _golemObject = other.GetComponent<Golem>();
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
