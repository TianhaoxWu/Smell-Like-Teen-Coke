using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector2 movement;
        public bool isJump;
        public Vector2 rotation;
    
        // Update is called once per frame
        void Update()
        {
            // move input
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        
            // jump input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
        
            // rotation input
            rotation.x = Input.GetAxis("Mouse X");
            rotation.y = Input.GetAxis("Mouse Y");
        }
    }  
}

