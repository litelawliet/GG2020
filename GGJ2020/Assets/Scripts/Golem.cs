using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Golem : MonoBehaviour
{
    [SerializeField] private int hp;
    private NavMeshAgent golemNavMesh;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMove;
    bool triggered;
    bool playerHit;
    bool wallHit;

    void Start()
    {
        golemNavMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(golemNavMesh.isActiveAndEnabled)
        {
            golemNavMesh.SetDestination(player.transform.position);
        }

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

        }

        if (collision.collider.CompareTag("Default"))
        {
            wallHit = true;
            ReduceHP();
        }
    }

    public void ReduceHP()
    {
        if (wallHit)
        {
            hp -= 2;
            wallHit = false;
        }
    }
    
    public NavMeshAgent GetNav()
    {
        return golemNavMesh;
    }
}
