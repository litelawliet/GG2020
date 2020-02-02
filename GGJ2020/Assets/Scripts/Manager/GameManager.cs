using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject golemPrefab = null;
        private List<GameObject> golems = new List<GameObject>();

        void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
                golems.Add(Instantiate(golemPrefab, position, Quaternion.identity));
            }
        }

        void Update()
        {

        }

        public List<GameObject> GetGolems()
        {
            return golems;
        }
    }
}
