using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    public float distance = 1f;
    public float speed = 5f;
    private Transform target;
    private bool running = false;
    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (!running && GetDis(transform.position, target.position) <= distance)
        {
            running = true;
        }
    }

    public float GetDis(Vector3 p1, Vector3 p2)
    {
        p1.y = 0f;
        p2.y = 0f;
        float dis = Vector3.Distance(p1, p2);
        Debug.Log(dis);
        return dis;
    }

    private void FixedUpdate()
    {
        if (running)
            transform.position += transform.forward * Time.deltaTime * speed;
    }
}
