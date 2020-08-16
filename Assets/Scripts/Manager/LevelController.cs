using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public Animator gameOverCanvas;

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

}
