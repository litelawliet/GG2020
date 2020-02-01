using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Golem : MonoBehaviour
{
    [SerializeField] private int hp;
    private NavMeshAgent golemNavMesh;
    [SerializeField] private GameObject golemScrap;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMove;
    [SerializeField] private PlayerHP playerHp;
    [SerializeField] private Animation[] golemAnim;
    bool _triggered;
    bool _wallHit;


    void Start()
    {
        golemNavMesh = GetComponent<NavMeshAgent>();
        playerHp = player.GetComponent<PlayerHP>();
    }

    void Update()
    {
        if (golemNavMesh.isActiveAndEnabled)
        {
            golemNavMesh.SetDestination(player.transform.position);
        }

        if (hp <= 0)
        {
            //Instantiate(golemScrap, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (_triggered)
        {
            transform.LookAt(player.transform.position);
            _triggered = false;
        }
    }

    private void TriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _triggered = true;
            golemAnim[1].Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerHp.ReduceHPPlayer();
        }

        else if (collision.collider.CompareTag("Environment"))
        {
            _wallHit = true;
            ReduceHP();
        }
        else
        {
            ReduceHP();
        }
    }

    public void ReduceHP()
    {
        if (_wallHit)
        {
            hp -= 2;
            _wallHit = false;
            Debug.Log(hp);
        }
        else
        {
            hp--;
            Debug.Log(hp);
        }
    }

    public void ReduceHP(int p_damage)
    {
        hp -= p_damage;    
    }


    public NavMeshAgent GetNav()
    {
        return golemNavMesh;
    }
}
