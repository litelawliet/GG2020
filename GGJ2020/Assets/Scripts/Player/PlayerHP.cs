using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int hp;


    void Start()
    {
        
    }

    void Update()
    {
        if (hp <= 0)
        {
            GameOver();
        }
    }

    public void ReduceHPPlayer()
    {
        hp -= 1;
    }

    public int GetHp()
    {
        return hp;
    }

    void GameOver()
    {

    }
}
