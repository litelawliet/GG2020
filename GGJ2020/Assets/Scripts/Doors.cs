using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private bool win;

    public void OpenDoor()
    {
        doorAnim.SetTrigger("DoorOpen");
        win = true;
    }

    public bool GetWin()
    {
        return win;
    }

}
