using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch= false;
    void Update()
    {

        horizontalMove= Input.GetAxisRaw("Horizontal")*runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
       
    }

     void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime,false,jump);
        jump = false;
        
    }
}
