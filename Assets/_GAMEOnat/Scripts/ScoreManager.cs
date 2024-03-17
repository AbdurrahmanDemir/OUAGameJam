using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public Image winPanel; 
    private int score = 0; 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateScore(int points)
    {
        if (score <= 0)
        {
            score = 0;
        }
        
        score += points; 
        scoreText.text = score.ToString();

        if(score >= 5)
        {
            EndGame();
        }

    }

    private void EndGame()
    {
        winPanel.gameObject.SetActive(true);
        PlayerPrefs.SetInt("RecycleGame", 1);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    
}