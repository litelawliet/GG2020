using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject golemPrefab = null;
        [SerializeField] private GameObject winScreen;
        [SerializeField] private PlayerMovement playerMove;
        [SerializeField] private Doors doorScript; //used to know when the player won the game
        private List<GameObject> golems = new List<GameObject>();
        [SerializeField] private List<Transform> positions = new List<Transform>();

        void Start()
        {

                //Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 6.0f, Random.Range(-10.0f, 10.0f));
                golems.Add(Instantiate(golemPrefab, positions[0].position, Quaternion.identity));
                golems.Add(Instantiate(golemPrefab, positions[1].position, Quaternion.identity));
                golems.Add(Instantiate(golemPrefab, positions[2].position, Quaternion.identity));
                golems.Add(Instantiate(golemPrefab, positions[3].position, Quaternion.identity));
                golems.Add(Instantiate(golemPrefab, positions[4].position, Quaternion.identity));
        }

        public void Update()
        {
            if (doorScript.GetWin())
            {
                winScreen.SetActive(true);
                playerMove.enabled = false;
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
