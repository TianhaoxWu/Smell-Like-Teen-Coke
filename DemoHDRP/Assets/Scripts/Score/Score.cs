using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : EventBase
{
    public ItemType itemType = ItemType.Coin;
    public int score;
    public bool isDestroy = false;

    public override void OnEventEnter(Transform target)
    {
        UIItem.Instance.AddItem(itemType, score);
        if (isDestroy)
        {
            Destroy(gameObject);
        }
    }
}
