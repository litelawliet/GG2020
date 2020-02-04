using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSpawn : MonoBehaviour
{
    [SerializeField] private GameObject golemPrefab = null;
    private List<GameObject> golems = new List<GameObject>();
    [SerializeField] private Transform golemSpawnPos;
    [SerializeField] private Manager.GameManager gameManager;
    [SerializeField] private Animator elevatorAnim;

    void ElevatorSpawnGolem()
    {
        elevatorAnim.SetBool("isSpawning", true);
        gameManager.SpawnGolems();
        //golems.Add(Instantiate(golemPrefab, golemSpawnPos.position, Quaternion.identity));
        StartCoroutine(WaitForAnimEnd(4));
    }

    IEnumerator WaitForAnimEnd(int sec)
    {
        yield return new WaitForSeconds(sec);
        elevatorAnim.SetBool("isSpawning", false);
    }

    private void Start()
    {
        ElevatorSpawnGolem();
    }

    void Update()
    {
        



    }
}
