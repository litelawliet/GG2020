using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject golemPrefab = null;
        private List<GameObject> golems = new List<GameObject>();

        void Start()
        {
            for (int i = 0; i < 1; i++)
            {
                Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
                golems.Add(Instantiate(golemPrefab, position, Quaternion.identity));
            }
        }

        public void OnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitAppli()
        {
            Application.Quit();
        }
        

        public List<GameObject> GetGolems()
        {
            return golems;
        }
    }
}
