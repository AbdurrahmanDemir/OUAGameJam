using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private Sprite nullStarImage;
    [SerializeField] private Sprite StarImage;
    [SerializeField] private SpriteRenderer[] gameSprite;
    [SerializeField] private Sprite[] gameCompletedSprite;
    [Header("Star")]
    public Image SeaStars;
    public Image RecycleStars;
    public Image WaterStars;
    private void Start()
    {
        startPanel.SetActive(true);
        if (!PlayerPrefs.HasKey("SeaGame"))
        {
            SeaStars.sprite = nullStarImage;
        }
        else
        {
            SeaStars.sprite= StarImage;
            gameSprite[0].sprite = gameCompletedSprite[0];
        }
        if (!PlayerPrefs.HasKey("RecycleGame"))
        {
            RecycleStars.sprite = nullStarImage;
        }
        else
        {
            RecycleStars.sprite = StarImage;
            gameSprite[1].sprite = gameCompletedSprite[1];
        }
        if (!PlayerPrefs.HasKey("WaterGame"))
        {
            WaterStars.sprite = nullStarImage;
        }
        else
        {
            WaterStars.sprite = StarImage;
            gameSprite[2].sprite = gameCompletedSprite[2];
        }


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
