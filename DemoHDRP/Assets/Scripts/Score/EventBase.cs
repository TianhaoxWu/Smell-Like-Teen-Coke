using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour
{
    public string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(targetTag))
        {
            OnEventEnter(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(targetTag))
        {
            OnEventExit(other.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(targetTag))
        {
            OnEventEnter(collision.transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag(targetTag))
        {
            OnEventExit(other.transform);
        }
    }

    public virtual void OnEventEnter(Transform target)
    {
        
    }

    public virtual void OnEventExit(Transform target)
    {
        
    }
}
