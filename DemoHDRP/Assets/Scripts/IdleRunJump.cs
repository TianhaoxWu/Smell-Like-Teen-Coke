using UnityEngine;
using System.Collections;

public class IdleRunJump : MonoBehaviour {


    // 用于管理角色动画的脚本
    protected Animator animator;  // 动画控制器
    public float DirectionDampTime = .25f;  // 方向平滑过渡时间
    public bool ApplyGravity = true;  // 是否应用重力

    // 在启动时进行初始化
    void Start()
    {
        animator = GetComponent<Animator>();  // 获取角色的动画控制器

        // 如果动画控制器的层数大于等于2，设置第二层的权重为1
        if (animator.layerCount >= 2)
            animator.SetLayerWeight(1, 1);
    }

    // 每帧更新调用
    void Update()
    {
        if (animator)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);  // 获取当前动画状态信息

            // 如果当前处于奔跑状态，按下Fire1键则设置Jump参数为true
            if (stateInfo.IsName("Base Layer.Run"))
            {
                if (Input.GetButton("Fire1")) animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);  // 否则设置Jump参数为false
            }

            // 如果按下Fire2键且动画控制器的层数大于等于2，切换Hi参数的值
            if (Input.GetButtonDown("Fire2") && animator.layerCount >= 2)
            {
                animator.SetBool("Hi", !animator.GetBool("Hi"));
            }

            // 获取水平和垂直输入
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // 根据输入的水平和垂直值设置动画参数
            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
        }
    }

}
