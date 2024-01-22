using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheck : EventBase
{
    public SpawnBuild spawn;
    public override void OnEventEnter(Transform target)
    {
        Destroy(target.gameObject);
        spawn.AddItem();
    }
}
