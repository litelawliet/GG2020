using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemHitbox : MonoBehaviour
{
    [SerializeField] private PlayerHP playerHp;
    [SerializeField] private int hp;
    [SerializeField] private bool wallHit;
    [SerializeField] private Golem golemScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHp.ReduceHPPlayer();
        }

        else if (collision.gameObject.CompareTag("Environment"))
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

    public void SetWallHit(bool p_wallHit)
    {
        wallHit = p_wallHit;
    }


 
}
