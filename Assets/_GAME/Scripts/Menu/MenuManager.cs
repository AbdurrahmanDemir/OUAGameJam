using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;

    private void Start()
    {
        startPanel.SetActive(true);
    }
    public void StartButton()
    {
        startPanel.SetActive(false);
    }

    public void SeaGameLoad()
    {
        SceneManager.LoadScene("SeaGame");
    }
    public void RecycleGameLoad()
    {
        SceneManager.LoadScene("RecycleGame");
    }
    public void WaterGameLoad()
    {
        SceneManager.LoadScene("WaterGame");
    }
}
