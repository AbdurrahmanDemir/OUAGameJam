using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public int wayNumber;
    private void Update()
    {        
        transform.position = Vector2.MoveTowards(transform.position, FishWay.instance.way[wayNumber].transform.position,.1f*Time.deltaTime);
    }
}
