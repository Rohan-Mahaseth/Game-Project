using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject winPanel;
    public TimerManager timerManager;

    private void Awake()
    {
        instance = this;
    }

    public void WinGame()
    {
        timerManager.StopTimer();

        winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}