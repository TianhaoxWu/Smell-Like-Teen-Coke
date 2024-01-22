using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Rotation : MonoBehaviour
{
    public Vector3 dir;
    public float rotationSpeed = 30f;
    public float positionTime = 1f;
    
    public Vector3 offset;
    private Vector3 from;
    private Vector3 to;

    private float currTime;
    
    // Start is called before the first frame update
    void Start()
    {
        //transform.localEulerAngles = UnityEngine.Random.Range(0, 180) * dir;
        //from = transform.localPosition;
        //to = @from + offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(dir, rotationSpeed * Time.deltaTime);
        //transform.localPosition = Vector3.Lerp(from, to, Mathf.PingPong(Time.time,positionTime)/positionTime);
    }
}
