using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // aseg�rate que la escena se llame as�
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
