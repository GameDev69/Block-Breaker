using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    } 

    public void LoadStartScreen ()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().resetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}