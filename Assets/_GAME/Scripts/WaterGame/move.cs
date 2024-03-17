using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    Camera kamera;
    Vector2 start_pose;

    GameObject[] pipe_list;

    public animActive aktive;

    private int pipe_count = 0;

    private void OnMouseDrag()
    {
        Vector3 pose = kamera.ScreenToWorldPoint(Input.mousePosition);
        pose.z = 0;
        transform.position = pose;
    }

    private void Start()
    {
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        start_pose = transform.position;

        pipe_list = GameObject.FindGameObjectsWithTag("seperate");

    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            foreach(GameObject seperate in pipe_list) 
            { 
                if(seperate.name == gameObject.name)
                {
                    float mesafe = Vector3.Distance(seperate.transform.position, transform.position);

                    if(mesafe <=0.2 )
                    {
                        transform.position = seperate.transform.position;
                        pipe_count++;
                        if(pipe_count==8 )
                        {
                            PlayerPrefs.SetInt("WaterGame", 1);
                            aktive.aktif();

                        }
                    }
                    else
                    {
                        transform.position = start_pose;
                    }
                }
            }
        }

    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("WaterGame", 1);
    }
}
