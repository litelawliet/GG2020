using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHP : MonoBehaviour
    {
        [SerializeField] private int life = 10;
        [SerializeField] private PlayerMovement playerMov;
        [SerializeField] private GameObject deathScreen;

        void Start()
        {
        }

        void Update()
        {
            if (life <= 0)
            {
                GameOver();
            }
        }

        public void ReduceLifeOf(int pLife)
        {
            life -= pLife;
        }

        public int Life()
        {
            return life;
        }

        public void GameOver()
        {
            Cursor.lockState = CursorLockMode.None;
            deathScreen.SetActive(true);
            playerMov.enabled = false;
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.CompareTag("Golem"))
        //    {
        //        ReduceLifeOf(1);
        //    }
        //}
    }
}