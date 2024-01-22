using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_ : MonoBehaviour
{
    // ���������ƶ����Ľű�
    private Animator ani;  // �������

    // ������ʱ���г�ʼ��
    void Start()
    {
        ani = GetComponent<Animator>();  // ��ȡ��ɫ�Ķ������
    }

    // ÿ֡���µ���
    void Update()
    {
        // �ڴ˿���������������߼�
    }

    // ������������봥������Χʱ����
    private void OnTriggerEnter(Collider other)
    {
        // ������������ı�ǩ��"Player"
        if (other.tag == "Player")
        {
            ani.SetBool("Open", true);  // ���ö�������"Open"Ϊtrue��������Ӧ�Ķ���
        }
    }

    // �����������뿪��������Χʱ����
    private void OnTriggerExit(Collider other)
    {
        // ����뿪������ı�ǩ��"Player"
        if (other.tag == "Player")
        {
            ani.SetBool("Open", false);  // ���ö�������"Open"Ϊfalse���ر���Ӧ�Ķ���
        }
    }

}
