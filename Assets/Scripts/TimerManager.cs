using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public TMP_Text timerText;

    private float elapsedTime = 0f;
    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format(
            "Time: {0:00}:{1:00}",
            minutes,
            seconds
        );
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public float GetTime()
    {
        return elapsedTime;
    }
}