using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItem : MonoBehaviour
{
    public static UIItem Instance;
    UIItemElement[] itemList;
    public Action<ItemType, int> addAct;

    private void Awake()
    {
        Instance = this;
        itemList = GetComponentsInChildren<UIItemElement>();
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void AddItem(ItemType type, int number)
    {
        UIItemElement item = GetItemElement(type);
        if (item == null)
        {
            if (addAct != null) addAct.Invoke(type, number);
        }
        else
        {
            item.AddItem(number);
            if (addAct != null)
            {
                addAct.Invoke(type, item.count);
            }
        }
    }

    public int GetItemCount(ItemType type)
    {
        UIItemElement item = GetItemElement(type);
        if (item != null)
        {
            return item.count;
        }
        return 0;
    }

    private UIItemElement GetItemElement(ItemType type)
    {
        foreach (var item in itemList)
        {
            if (item.ItemType == type)
            {
                return item;
            }
        }
        return null;
    }
}

public enum ItemType
{
    None,
    Coin,
    Damage,
}