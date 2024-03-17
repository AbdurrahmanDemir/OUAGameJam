using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishWay : MonoBehaviour
{
    public static FishWay instance;

    [Header("Elements")]
     public Transform[] way;
    [SerializeField] private GameObject[] fish;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        for (int i = 0; i < way.Length; i++)
        {
            GameObject go = Instantiate(fish[i], way[i].transform);
            go.transform.position= way[i].transform.position;
        }
    }
}
