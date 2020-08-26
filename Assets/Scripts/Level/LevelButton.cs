using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int level, cost;
    private Button button;
    public Text costText;
    private Menu menu;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.level >= level) button.interactable = false;
        menu = FindObjectOfType<Menu>();

        costText.text = cost.ToString();
    }

    public void BuyLevel()
    {
        if (GameManager.instance.totalPoints < cost || (GameManager.instance.level + 1) != level) return;

        button.interactable = false;
        GameManager.instance.level = level;
        GameManager.instance.totalPoints -= cost;
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("TotalPoints", GameManager.instance.totalPoints);
        menu.UpdateTotalPoints();
    }
}
