using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class TrashCan : MonoBehaviour
{
    private bool collisionDetected = false; 
    private bool equalityDetected = false;
    private float lastSpacePressTime = 0f;
    [SerializeField] private float spacePressDelay = 0.1f; 
    public GameObject correctPrefab; 
    public GameObject wrongPrefab; 
    public AudioSource correctSound;
    public AudioSource wrongSound;
    [SerializeField] public Image correctPanel;
    [SerializeField] public Image wrongPanel;
    private void start()
    {
        correctSound = GetComponent<AudioSource>();
        wrongSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionDetected = true;
        string otherTag = other.gameObject.tag;

        if (otherTag == gameObject.tag)
        {
            equalityDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        collisionDetected = false;
        equalityDetected = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastSpacePressTime >= spacePressDelay)
        {
            if (equalityDetected)
            {
                correctSound.Play();
                correctPanel.gameObject.SetActive(true);
                Invoke("HideCorrectPanel", 0.5f);
                GameObject correctInstance = Instantiate(correctPrefab, transform.position, Quaternion.identity);
                Destroy(correctInstance, 0.5f); 
                ScoreManager.instance.UpdateScore(1);
            }
            else if(collisionDetected)
            {
                wrongSound.Play();
                wrongPanel.gameObject.SetActive(true);
                Invoke("HideWrongPanel", 0.5f); 
                GameObject wrongInstance = Instantiate(wrongPrefab, transform.position, Quaternion.identity);
                Destroy(wrongInstance, 0.5f); 
                ScoreManager.instance.UpdateScore(-1);
            }
            else
            {
                ScoreManager.instance.UpdateScore(0); 
            }
            lastSpacePressTime = Time.time; 
        }
    }
    
    private void HideCorrectPanel()
    {
        correctPanel.gameObject.SetActive(false);
    }

    private void HideWrongPanel()
    {
        wrongPanel.gameObject.SetActive(false);
    }
}



