using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_test : MonoBehaviour {

    Animator anim;
    public Rigidbody2D body;
    public float verticalSpeed;
    public float horizontalSpeed;
    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        verticalSpeed = body.velocity.y;
        horizontalSpeed = body.velocity.x;

        if (horizontalSpeed !=0.0f && verticalSpeed == 0.0f)
        {
            
            Walk();

        }
        if (horizontalSpeed == 0.0f && verticalSpeed ==0.0f)
        {
           Idle();

        }
        if (verticalSpeed != 0.0f)
        {
           // ResetState();
           Jump();

        }

        if ( TouchControl.inputState == TouchControl.InputState.UpperLeft || TouchControl.inputState == TouchControl.InputState.UpperRight ||
            TouchControl.inputState == TouchControl.InputState.Left || TouchControl.inputState == TouchControl.InputState.Right )
        {
            ResetState();
            Kick();
            //TouchControl.inputState == TouchControl.InputState.Up ||

        }


        /*
                if (Input.GetKey(KeyCode.D))
                {
                    anim.SetBool("walk",true);
                    anim.SetBool("idle", false);
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    anim.SetBool("walk", false);
                    anim.SetBool("idle", true);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    anim.SetBool("walk", true);
                    anim.SetBool("idle", false);

                }

                if (Input.GetKeyUp(KeyCode.A))
                {
                    anim.SetBool("walk", false);
                    anim.SetBool("idle", true);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("jump");
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetTrigger("kick");
                }

                   // anim.SetBool("walk", false);

            */

    }


    public void Idle()
    {
        anim.SetBool("walk", false);
        anim.SetBool("idle", true);
        anim.SetBool("jump", false);
       

    }
    public void Walk()
    {
        anim.SetBool("walk", true);
        anim.SetBool("idle", false);
        anim.SetBool("jump", false);
        
    }
    public void Kick()
    {
        anim.SetTrigger("kick");
        anim.SetBool("jump", false);
    }
    public void Jump()
    {
        anim.SetBool("walk", false);
        anim.SetBool("idle", false);
        anim.SetBool("jump",true);
        
    }



    public void ResetState()
    {
        anim.SetBool("walk", false);
        anim.SetBool("idle", false);
        anim.SetBool("jump", false);


    }
}
