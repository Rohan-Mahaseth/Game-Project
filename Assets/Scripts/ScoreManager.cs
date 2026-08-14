using System.Collections;
using TMPro;
using UnityEngine;

// UPGRADED VERSION — replaces your old ScoreManager.cs
// Same logic, but the score text "pops" (scales up and back) when it changes.
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public float popScale = 1.35f;
    public float popTime = 0.18f;

    private int score = 0;
    private Coroutine popRoutine;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        if (popRoutine != null) StopCoroutine(popRoutine);
        popRoutine = StartCoroutine(Pop());
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: <color=#3DDC97>" + score + "</color>";
    }

    private IEnumerator Pop()
    {
        Transform t = scoreText.transform;
        float half = popTime * 0.5f;

        // scale up
        for (float e = 0f; e < half; e += Time.unscaledDeltaTime)
        {
            t.localScale = Vector3.one * Mathf.Lerp(1f, popScale, e / half);
            yield return null;
        }
        // scale back
        for (float e = 0f; e < half; e += Time.unscaledDeltaTime)
        {
            t.localScale = Vector3.one * Mathf.Lerp(popScale, 1f, e / half);
            yield return null;
        }

        t.localScale = Vector3.one;
    }

    public int GetScore()
    {
        return score;
    }
}
