using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("ShoppingGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}