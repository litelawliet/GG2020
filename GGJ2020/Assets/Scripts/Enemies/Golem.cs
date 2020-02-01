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
    [SerializeField] private Animator golemAnim;
    [SerializeField] private GolemHitbox golemHitbox;
    [SerializeField] private float minDistance;
    [SerializeField] private Vector3 playerDistance;

    bool _triggered;


    void Start()
    {
        golemNavMesh = GetComponent<NavMeshAgent>();
        playerHp = player.GetComponent<PlayerHP>();
    }

    void Update()
    {
        if (!_triggered)
        {
            golemNavMesh.speed = 6;
        }
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
            golemNavMesh.speed = 1;
            transform.LookAt(player.transform.position);
            golemAnim.SetTrigger("Attacc");
            _triggered = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _triggered = true;
        }
    }

    public void ReduceHP()
    {
        if (golemHitbox.IsWallHit())
        {
            hp -= 2;
            golemHitbox.SetWallHit(false);
        }
        else
        {
            hp--;
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
