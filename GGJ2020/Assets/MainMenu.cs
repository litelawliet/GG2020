using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(int buildIndexScene)
    {
        SceneManager.LoadScene(buildIndexScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
