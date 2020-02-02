using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private GameObject balance;
    [SerializeField] private Animator balanceAnim;
    [SerializeField] private Doors doorScript;
    private int _coreToBring;


    void Start()
    {
        _coreToBring = 1;
    }

    public void AddCore()
    {
        _coreToBring--;
        balance.transform.position -= new Vector3(0, 0.2f, 0);
        balanceAnim.SetTrigger("Weight");

        if (_coreToBring <=0)
        {
            doorScript.OpenDoor();
        }
    }
}
