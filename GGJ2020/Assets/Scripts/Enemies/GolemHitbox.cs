using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemHitbox : MonoBehaviour
{
    [SerializeField] private PlayerHP playerHp;
    [SerializeField] private int hp;
    bool _wallHit;

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
}
