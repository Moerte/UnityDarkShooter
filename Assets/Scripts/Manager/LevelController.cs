using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public Text scoreText;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameOver()
    {
        gameOverCanvas.SetTrigger("GameOver");
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

}
