using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;

    public void OpenDoor()
    {
        doorAnim.SetBool("DoorOpen", true);
    }

    public bool GetWin()
    {
        return doorAnim.GetBool("DoorOpen");
    }

}
