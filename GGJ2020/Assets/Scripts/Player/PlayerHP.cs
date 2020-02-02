using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHP : MonoBehaviour
    {
        [SerializeField] private int life = 10;


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

        void GameOver()
        {
            Debug.Log("GAMEOVER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("GolemProjectile"))
            {
                ReduceLifeOf(1);
            }
        }
    }
}