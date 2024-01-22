using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public float[] xPosList = new float[] {-2.5f, 0, 2.5f};
    public int index = 1;
    public Animator animator;
    private Vector3 toPos;
    private Vector3 fromPos;
    public float moveTime = 1f;
    private float currTime = 0f;
    private bool canInput = true;

    public float moveSpeed = 4f;
    public float jumpSpeed = 5f;
    public float gravity = -9.8f;
    private CharacterController character;
    private Vector3 moveDir;
    private float t = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // move
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index > 0)
            {
                index--;
                OnMoveH();
            }
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            if (index < xPosList.Length - 1)
            {
                index++;
                OnMoveH();
            }
        }
        
        // jump
        if (character.isGrounded)
        {
            moveDir = Vector3.zero;
            
            if (Input.GetButton("Jump"))
            {
                animator.SetTrigger("jump");
                moveDir.y = jumpSpeed;
            }
        }
        
        moveDir.y += gravity * Time.deltaTime;
        character.Move(moveDir * moveSpeed * Time.deltaTime);
        animator.SetBool("ground", character.isGrounded);
    }

    private void FixedUpdate()
    {
        // move
        if (t <= 1f)
        {
            currTime += Time.deltaTime;
            t = currTime / moveTime;
            Vector3 pos = transform.localPosition;
            pos.x = Mathf.Lerp(fromPos.x, toPos.x, t);
            transform.localPosition = pos;
            //transform.localPosition = Vector3.Lerp(fromPos, toPos, t);
            
            if (t == 1) t = 2;
        }
    }

    private void OnMoveH()
    {
        fromPos = transform.localPosition;
        toPos = fromPos;
        toPos.x = xPosList[index];
        currTime = 0;
        t = 0;
    }

    private float GetHDistance(Vector3 p1, Vector3 p2)
    {
        p1.y = 0;
        p2.y = 0;
        float dis = Vector3.Distance(p1, p2);
        return dis;
    }
}
