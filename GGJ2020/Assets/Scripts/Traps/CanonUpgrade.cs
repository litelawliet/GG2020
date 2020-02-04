using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject canonPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeToCanon()
    {
        gameObject.SetActive(false);
        if (canonPrefab != null)
            Instantiate(canonPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
