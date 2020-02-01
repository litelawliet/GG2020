using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject golemPrefab = null;
    private List<GameObject> golems = null;
    
    // Start is called before the first frame update
    void Start()
    {
        golems = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
            golems.Add(Instantiate(golemPrefab, position, Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<GameObject> GetGolems()
    {
        return golems;
    }
}
