using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController audcon;  // 静态变量，用于存储AudioController的实例
    public AudioSource aud;  // 音频源组件
    public AudioClip coinclip, finishclip;  // 金币和游戏结束的音频剪辑

    private void Awake()
    {
        audcon = this;  // 在唤醒时，将当前实例赋值给静态变量audcon
    }

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();  // 获取AudioSource组件
    }

    // Update is called once per frame
    void Update()
    {
        // 在Update中通常不做任何处理
    }

    // 播放金币音效的方法
    public void coinplay()
    {
        aud.PlayOneShot(coinclip);  // 使用PlayOneShot播放金币音效
    }

    // 播放游戏结束音效的方法
    public void finish()
    {
        aud.PlayOneShot(finishclip);  // 使用PlayOneShot播放游戏结束音效
    }

}
