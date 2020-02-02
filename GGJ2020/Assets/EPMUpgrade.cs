using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPMUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject epmPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpgradeToEPM()
    {
        gameObject.SetActive(false);
        if (epmPrefab != null)
            Instantiate(epmPrefab, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
}
