using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunController : MonoBehaviour
{
    [Header("Elements")]
    public float moveSpeed;
    Rigidbody2D rb;
    Animator animator;

    [Header("Other")]
    public GameObject[] gamePanels;
    public Camera cam;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        PlayerMove();

        if (rb.velocity.magnitude > 0.1f)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
      
    }

    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "finishLine")
        {
            if (PlayerPrefs.GetInt("SeaGame") == 1&&PlayerPrefs.GetInt("RecycleGame") == 1&& PlayerPrefs.GetInt("WaterGame") == 1)
            {
                Debug.Log("oyun bitti");
            }
            else
            {
                Debug.Log("oyun bitmedi");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "first")
        {
            gamePanels[0].gameObject.SetActive(true);
            cam.orthographicSize = 4;
        }
        if (collision.gameObject.tag == "second")
        {
            gamePanels[1].gameObject.SetActive(true);
            cam.orthographicSize = 4;
        }
        if (collision.gameObject.tag == "third")
        {
            gamePanels[2].gameObject.SetActive(true);
            cam.orthographicSize = 4;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "first")
        {
            gamePanels[0].gameObject.SetActive(false);
            cam.orthographicSize = 5;
        }
        if (collision.gameObject.tag == "second")
        {
            gamePanels[1].gameObject.SetActive(false);
            cam.orthographicSize = 5;
        }
        if (collision.gameObject.tag == "third")
        {
            gamePanels[2].gameObject.SetActive(false);
            cam.orthographicSize = 5;
        }
    }
}
