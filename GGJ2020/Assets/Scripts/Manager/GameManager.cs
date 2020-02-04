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
        [SerializeField] private MouseLook cameraMove;
        [SerializeField] private Doors doorScript; //used to know when the player won the game
        private List<GameObject> golems = new List<GameObject>();
        [SerializeField] private List<Transform> positions = new List<Transform>();

        public void SpawnGolems()
        {
            //Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 6.0f, Random.Range(-10.0f, 10.0f));
            if (positions.Contains(positions[0]))
            {
                for (int i = 0; i < positions.LastIndexOf(positions[i]); i++)
                {
                    golems.Add(Instantiate(golemPrefab, positions[i].position, Quaternion.identity));
                    //golems.Add(Instantiate(golemPrefab, positions[1].position, Quaternion.identity));
                    //golems.Add(Instantiate(golemPrefab, positions[2].position, Quaternion.identity));
                    //golems.Add(Instantiate(golemPrefab, positions[3].position, Quaternion.identity));
                    //golems.Add(Instantiate(golemPrefab, positions[4].position, Quaternion.identity));

                }
            }
        }

        public void Update()
        {
            if (doorScript.GetWin())
            {
                Cursor.lockState = CursorLockMode.None;
                winScreen.SetActive(true);
                playerMove.enabled = false;
                cameraMove.enabled = false;
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
