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
        StartCoroutine(WaitForAnimEnd(4));
    }

    IEnumerator WaitForAnimEnd(int sec)
    {
        yield return new WaitForSeconds(sec);
        //gameManager.SpawnGolems();
        golems.Add(Instantiate(golemPrefab, golemSpawnPos.position, Quaternion.identity));
        gameManager.SetGolemList(golems);
        elevatorAnim.SetBool("isSpawning", false);
    }

    private void Start()
    {
        ElevatorSpawnGolem();
    }

    void Update()
    {
        
        // si il ne reste plus qu'un golem sur la list tous les spawn font pop 1 golem


    }
}
