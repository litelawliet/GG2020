using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Golem : MonoBehaviour
{
    public int hp;
    public NavMeshAgent golem;
    public GameObject player;
    bool triggered;
    
    void Start()
    {

    }

    void Update()
    {
        golem.SetDestination(player.transform.position);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        if (triggered)
        {
            transform.LookAt(player.transform.position);
            triggered = false;
        }
    }

    private void TriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            triggered = true;
            //lancer animation d'attaque
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerMovement>())
        {
            //player.hp--;
        }
        if (collision.collider.CompareTag("Default"))
        {
            hp = hp - 2;
        }
    }

}
