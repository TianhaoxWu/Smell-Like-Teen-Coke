using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_ : MonoBehaviour
{
    // 触发器控制动画的脚本
    private Animator ani;  // 动画组件

    // 在启动时进行初始化
    void Start()
    {
        ani = GetComponent<Animator>();  // 获取角色的动画组件
    }

    // 每帧更新调用
    void Update()
    {
        // 在此可以添加其他更新逻辑
    }

    // 当其他物体进入触发器范围时调用
    private void OnTriggerEnter(Collider other)
    {
        // 如果进入的物体的标签是"Player"
        if (other.tag == "Player")
        {
            ani.SetBool("Open", true);  // 设置动画参数"Open"为true，触发相应的动画
        }
    }

    // 当其他物体离开触发器范围时调用
    private void OnTriggerExit(Collider other)
    {
        // 如果离开的物体的标签是"Player"
        if (other.tag == "Player")
        {
            ani.SetBool("Open", false);  // 设置动画参数"Open"为false，关闭相应的动画
        }
    }

}
