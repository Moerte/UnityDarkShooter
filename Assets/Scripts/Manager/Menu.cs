using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Text totalPointsText;

    private void Start()
    {
        UpdateTotalPoints();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void DeleteKeys()
    {
        PlayerPrefs.DeleteAll();
    }

    public void UpdateTotalPoints()
    {
        totalPointsText.text = "Total Points: " + GameManager.instance.totalPoints;
    }
}
