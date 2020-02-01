using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Golem golem;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golem"))
        {
            particle.Play();
            golem.GetNav().enabled = false;
            StartCoroutine(Waitfor5sec());
        }
    }

    IEnumerator Waitfor5sec()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
        golem.GetNav().enabled = true;
    }
}
