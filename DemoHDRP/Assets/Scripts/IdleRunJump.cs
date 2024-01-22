using UnityEngine;
using System.Collections;

public class IdleRunJump : MonoBehaviour {


    // ���ڹ����ɫ�����Ľű�
    protected Animator animator;  // ����������
    public float DirectionDampTime = .25f;  // ����ƽ������ʱ��
    public bool ApplyGravity = true;  // �Ƿ�Ӧ������

    // ������ʱ���г�ʼ��
    void Start()
    {
        animator = GetComponent<Animator>();  // ��ȡ��ɫ�Ķ���������

        // ��������������Ĳ������ڵ���2�����õڶ����Ȩ��Ϊ1
        if (animator.layerCount >= 2)
            animator.SetLayerWeight(1, 1);
    }

    // ÿ֡���µ���
    void Update()
    {
        if (animator)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);  // ��ȡ��ǰ����״̬��Ϣ

            // �����ǰ���ڱ���״̬������Fire1��������Jump����Ϊtrue
            if (stateInfo.IsName("Base Layer.Run"))
            {
                if (Input.GetButton("Fire1")) animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);  // ��������Jump����Ϊfalse
            }

            // �������Fire2���Ҷ����������Ĳ������ڵ���2���л�Hi������ֵ
            if (Input.GetButtonDown("Fire2") && animator.layerCount >= 2)
            {
                animator.SetBool("Hi", !animator.GetBool("Hi"));
            }

            // ��ȡˮƽ�ʹ�ֱ����
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // ���������ˮƽ�ʹ�ֱֵ���ö�������
            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
        }
    }

}
