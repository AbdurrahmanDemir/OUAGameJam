using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Garbage")
        {
            Destroy(collision.gameObject);
            WaterGameManager.instance.CollectGarbage();
        }
    }
}
