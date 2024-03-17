using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animActive : MonoBehaviour
{
    public GameObject su_gif;

    private void Start()
    {
        su_gif.SetActive(false);

    }

    public void aktif()
    {
        su_gif.SetActive(true);
    }
}
