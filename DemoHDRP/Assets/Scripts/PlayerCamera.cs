using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class PlayerCamera : MonoBehaviour
{
    public PlayerInput playerInput;
    public CursorLockMode lockMode;
    
    public Transform target;
    public Transform cameraTsfm;

    // rotation speed
    public float mousespeed = 5f;
    // vertical rotation range
    public Vector2 limitAngleY = new Vector2(-45,45);
    // right mousedown to rotation view 
    public bool isRightMouseRotate;

    private Vector3 cameraAngle;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = lockMode;
        offset = transform.position - target.position;
        cameraAngle = transform.eulerAngles;
    }

    private void FixedUpdate()
    {
        transform.position = target.position + offset;

        if (!isRightMouseRotate || (isRightMouseRotate && Input.GetMouseButton(1)))
        {
            // horizontal rotation
            float angleX = playerInput.rotation.x * mousespeed;
            cameraAngle.y += angleX;
            cameraTsfm.RotateAround(target.position, Vector3.up, angleX);

            // vertical rotation
            cameraAngle.x -= playerInput.rotation.y * mousespeed;
            cameraAngle.x = Mathf.Clamp(cameraAngle.x, limitAngleY.x, limitAngleY.y);
            cameraTsfm.rotation = Quaternion.Euler(cameraAngle);
        }
    }
}
