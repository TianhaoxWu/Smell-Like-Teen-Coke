using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestroy : EventBase
{
    public override void OnEventEnter(Transform target)
    {
        Destroy(target.gameObject);
    }
}
