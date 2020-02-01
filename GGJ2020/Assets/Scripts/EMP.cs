using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour
{
    public ParticleSystem particle;
    public Golem golem;
    float timer;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golem"))
        {
            particle.Play();
            timer += Time.deltaTime;
            golem.golem.SetDestination(golem.transform.position);

            if (timer >= 5)
            {
                golem.golem.SetDestination(player.transform.position);
            }
        }
    }
}
