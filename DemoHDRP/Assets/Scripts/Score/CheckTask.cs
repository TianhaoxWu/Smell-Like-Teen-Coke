using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CheckTask : MonoBehaviour
{
    public int targetScore = 200;

    public AudioClip coin;
    public AudioClip over;
    public AudioClip win;
    public GameObject overObj;
    public GameObject winObj;

    private Vector3 point;
    private bool first = true;
    
    // Start is called before the first frame update
    void Start()
    {
        UIItem.Instance.addAct = OnAddItem;
        point = GameObject.FindWithTag("Player").transform.position;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (first && Input.anyKeyDown)
        {
            first = false;
            Time.timeScale = 1f;
        }
    }

    private void OnAddItem(ItemType type, int number)
    {
        if (type == ItemType.Damage)
        {
            //return;
            // game over
            Time.timeScale = 0f;
            AudioSource.PlayClipAtPoint(over, point);
            overObj.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            AudioSource.PlayClipAtPoint(coin, point);
            if (number >= targetScore)
            {
                // win
                Time.timeScale = 0f;
                AudioSource.PlayClipAtPoint(win, point);
                winObj.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
