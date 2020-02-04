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

        //public void SpawnGolems()
        //{
        //    if (positions.Contains(positions[0]))
        //    {
        //        for (int i = 0; i < positions.LastIndexOf(positions[i]); i++)
        //        {
        //            golems.Add(Instantiate(golemPrefab, positions[i].position, Quaternion.identity));

        //        }
        //    }
        //}

        public void SetGolemList(List<GameObject> p_List)
        {
            golems = p_List;
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
