using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaterGameManager : MonoBehaviour
{
    public static WaterGameManager instance;
    public Slider slider;
    public GameObject overPanel;

    int garbage;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 5;
    }

    public void CollectGarbage()
    {
        garbage++;
        slider.value = garbage;

        if (garbage == 5)
        {
            overPanel.SetActive(true);
            PlayerPrefs.SetInt("SeaGame", 1);
        }
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
