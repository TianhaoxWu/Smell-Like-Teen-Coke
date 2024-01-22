using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;

    private int animIDSpeed;
    private int animIDJump;
    private int animIDGround;

    // Start is called before the first frame update
    void Awake()
    {
        animIDSpeed = Animator.StringToHash("movespeed");
        animIDJump = Animator.StringToHash("jump");
        animIDGround = Animator.StringToHash("ground");
    }

    public virtual void OnMove(float speed)
    {
        if (animator)
        {
            animator.SetFloat(animIDSpeed, speed);
        }
    }

    public virtual void OnJump()
    {
        if (animator)
        {
            animator.SetTrigger(animIDJump);
            animator.SetBool(animIDGround, false);
        }
    }

    public virtual void OnGround()
    {
        if (animator)
        {
            animator.SetBool(animIDGround, true);
        }
    }
}
