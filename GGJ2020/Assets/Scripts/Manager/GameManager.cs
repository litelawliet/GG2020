using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject golemPrefab = null;
        [SerializeField] private GameObject winScreen;
        [SerializeField] private Player.PlayerMovement playerMove;
        [SerializeField] private Doors doorScript; //used to know when the player won the game
        private List<GameObject> golems = new List<GameObject>();

        void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 6.0f, Random.Range(-10.0f, 10.0f));
                golems.Add(Instantiate(golemPrefab, position, Quaternion.identity));
            }
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
