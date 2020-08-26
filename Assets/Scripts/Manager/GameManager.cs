using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int totalPoints, maxScore;

    public int level;
    public Level[] levels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        totalPoints = PlayerPrefs.GetInt("TotalPoints");
        maxScore = PlayerPrefs.GetInt("MaxScore");

        level = PlayerPrefs.GetInt("Level");
    }

}
