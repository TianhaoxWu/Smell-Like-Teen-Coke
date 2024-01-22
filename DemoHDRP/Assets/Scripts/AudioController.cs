using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController audcon;  // ��̬���������ڴ洢AudioController��ʵ��
    public AudioSource aud;  // ��ƵԴ���
    public AudioClip coinclip, finishclip;  // ��Һ���Ϸ��������Ƶ����

    private void Awake()
    {
        audcon = this;  // �ڻ���ʱ������ǰʵ����ֵ����̬����audcon
    }

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();  // ��ȡAudioSource���
    }

    // Update is called once per frame
    void Update()
    {
        // ��Update��ͨ�������κδ���
    }

    // ���Ž����Ч�ķ���
    public void coinplay()
    {
        aud.PlayOneShot(coinclip);  // ʹ��PlayOneShot���Ž����Ч
    }

    // ������Ϸ������Ч�ķ���
    public void finish()
    {
        aud.PlayOneShot(finishclip);  // ʹ��PlayOneShot������Ϸ������Ч
    }

}
