using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spline : MonoBehaviour
{
    public GameObject start;
    public GameObject end;

    public Vector3 startPoint;
    public Vector3 endPoint;
    public Vector3 point1;
    public Vector3 point2;


    private Vector3 movePos;
    private Vector3 a;
    private Vector3 a_half;
    private float b;

    //private Vector3 lenth;
    private float lenth;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = start.transform.position;
        endPoint = end.transform.position;
        lenth = (startPoint - endPoint).magnitude;
        //movePos = transform.position;
        //ffffPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        WhatPos();
        transform.position = Vector3.MoveTowards(transform.position, movePos, 10f);
    }

    void WhatPos()
    {
        float d = (end.transform.position - start.transform.position).magnitude;
        Mathf.Abs(d);
        b = Mathf.Sqrt(Mathf.Pow(lenth / 2, 2f) - Mathf.Pow(d/2, 2f));

        Debug.Log(b);

        movePos = (startPoint + endPoint) / 2;
        movePos.x += b;
        //movePos.z += (d-lenth)/2;
    }
}
