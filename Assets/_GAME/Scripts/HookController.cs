using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    [Header("Elements")]
    public GameObject hookParent;


    [Header("Settings")]
    [SerializeField] private float hookRotateSpeed;
    [SerializeField] private float rotateAngle=5f;
    [SerializeField] private float maxZAngel;
    [SerializeField] private float minZAngel;
    [SerializeField] private float throwSpeed;
    float startY;

    bool isRight;
    bool canRotate;
    bool _throw;



    void Start()
    {
        startY= hookParent.transform.position.y;
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        HookRotate();
        HookThrow();
        HookMove();
    }

    private void HookRotate()
    {
        if (!canRotate)
            return;

        if (isRight)
            rotateAngle += hookRotateSpeed * Time.deltaTime;
        else
            rotateAngle -= hookRotateSpeed * Time.deltaTime;

        hookParent.transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);

        if (rotateAngle >= maxZAngel)
            isRight = false;
        else if (rotateAngle <= minZAngel)
            isRight = true;
    }

    private void HookThrow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canRotate)
            {
                canRotate = false;
                _throw = true;
            }

        }
    }
    void HookMove()
    {
        if (canRotate)
            return;

        if (!canRotate)
        {
            Vector3 temp= hookParent.transform.position;

            if (_throw)
                temp -= hookParent.transform.up * Time.deltaTime * throwSpeed;
            else
                temp += hookParent.transform.up * Time.deltaTime*throwSpeed;

            hookParent.transform.position = temp;

            if(temp.y<=-5f)
                _throw = false;

            if (temp.y > startY)
            {
                canRotate = true;
            }

        }
    }
}
