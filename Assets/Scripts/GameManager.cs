using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public BallController ball;
    public Text leftScoreText;
    public Text rightScoreText;
    public Text highScoreText;

    public int leftScore = 0;
    public int rightScore = 0;
    public int winningScore = 10;

    void Start()
    {
        UpdateUI();
        UpdateHighScoreUI();
    }

    public void ScoreLeft()
    {
        leftScore++;
        UpdateUI();
        CheckWin();
        StartCoroutine(RestartRound());
    }

    public void ScoreRight()
    {
        rightScore++;
        UpdateUI();
        CheckWin();
        StartCoroutine(RestartRound());
    }

    IEnumerator RestartRound()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.position = Vector2.zero;
        yield return new WaitForSeconds(1f);
        ball.Launch();
    }

    void UpdateUI()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    void CheckWin()
    {
        if (leftScore >= winningScore || rightScore >= winningScore)
        {
            int max = Mathf.Max(leftScore, rightScore);
            int high = PlayerPrefs.GetInt("HighScore", 0);
            if (max > high)
            {
                PlayerPrefs.SetInt("HighScore", max);
                PlayerPrefs.Save();
            }

            //muestra pantalla de Game Over - Por ahora solo se reinicia
            leftScore = 0;
            rightScore = 0;
            UpdateUI();
            UpdateHighScoreUI();
        }
    }

    void UpdateHighScoreUI()
    {
        highScoreText.text = "High: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}

