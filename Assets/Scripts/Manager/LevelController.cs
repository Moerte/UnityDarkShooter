using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public Text scoreText, gameOverScoreText;
    public Animator gameOverCanvas;

    private int score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != null){
            Destroy(gameObject);
        }
    }
    public int getScore()
    {
        return this.score;
    }

    public void GameOver()
    {
        int record = 0;
        gameOverCanvas.SetTrigger("GameOver");
        if(GameManager.instance != null)
        {
            GameManager.instance.totalPoints += score;
            PlayerPrefs.SetInt("TotalPoints", GameManager.instance.totalPoints);
            if(score > GameManager.instance.maxScore)
            {
                GameManager.instance.maxScore = score;
                PlayerPrefs.SetInt("MaxScore", GameManager.instance.maxScore);
            }
            record = GameManager.instance.maxScore;
        }
        gameOverScoreText.text = "Score: "+ score + "\nRecord: "+ record;
    }

    public void UpdateScore(int amountPoints)
    {
        score += amountPoints;
        scoreText.text = "Pontos: " + score;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuReloadScene()
    {   
        SceneManager.LoadScene(0);
    }

}
