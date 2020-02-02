using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TeslaUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject teslaPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeToTesla()
    {
        gameObject.SetActive(false);
        if (teslaPrefab != null)
            Instantiate(teslaPrefab, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
}
