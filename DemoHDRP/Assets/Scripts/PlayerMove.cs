using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class PlayerMove : MonoBehaviour
{
    [Header("move speed")]
    public float moveSpeed = 4;
    [Header("jump speed")]
    public float jumpSpeed = 5;
    // gravity
    public float gravity = 9.8f;
    // ground point
    public Transform groundCheck;
    // ground check radius
    public float checkRadius = 0.15f;
    // ground move layer
    public LayerMask groundLayer;
    [HideInInspector]public bool isOnground = true;
    [HideInInspector]public bool isJump;
    
    private CharacterController cc;
    // input value
    private float horizontalMove, verticalMove;
    // move dir
    private Vector3 dir;
    public Vector3 velocity;

    private PlayerInput playerInput;
    public Transform cameraTsfm;
    public AudioSource jumpClip;
    public AudioSource stepClip;
    public PlayerAnimator animation;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cc = GetComponent<CharacterController>();
        if (cameraTsfm == null)
        {
            cameraTsfm = Camera.main.transform;
        }
        animation = GetComponent<PlayerAnimator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //check ground status
       isOnground = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        if (isOnground && velocity.y < 0)
        {
            velocity.y = -1f;
            if (isJump)
            {
                isJump = false;
                if (animation != null)
                {
                    animation.OnGround();
                }                
            }
        }
        
        if (playerInput.movement == Vector2.zero)
        {
            // stand
            if (animation != null)
            {
                animation.OnMove(0);
            }            
            stepClip.Stop();
        }
        else
        {
            // horizontal move
            dir = cameraTsfm.forward * playerInput.movement.y + cameraTsfm.right * playerInput.movement.x;
            dir.y = 0f;
            transform.LookAt(transform.position + dir * moveSpeed * Time.deltaTime);
            cc.Move(dir * moveSpeed * Time.deltaTime);

            if (animation != null)
            {
                animation.OnMove(1);
            }
            stepClip.Play();
        }

        // jump
        if (playerInput.isJump && isOnground)
        {
            velocity.y = jumpSpeed;
            isJump = true;
            jumpClip.Play();
            if (animation != null)
            {
                animation.OnJump();
            }            
        }

        // fall
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        playerInput.isJump = false;
    }
}
