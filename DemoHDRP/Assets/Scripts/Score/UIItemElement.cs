using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemElement : MonoBehaviour
{
    public ItemType ItemType;
    public Text numberText;
    public int count;

    public void AddItem(int number)
    {
        count += number;
        numberText.text = count.ToString();
    }
}
