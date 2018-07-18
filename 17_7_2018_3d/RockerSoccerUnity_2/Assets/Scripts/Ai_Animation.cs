using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Animation : MonoBehaviour {


    Animator anim;
    public Rigidbody2D body;
    public float verticalSpeed;
    public float horizontalSpeed;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed = body.velocity.y;
        horizontalSpeed = body.velocity.x;

        if (horizontalSpeed != 0.0f && verticalSpeed == 0.0f)
        {

            Walk();

        }
        if (horizontalSpeed == 0.0f && verticalSpeed == 0.0f)
        {
            Idle();

        }
        if (verticalSpeed != 0.0f)
        {
            // ResetState();
            Jump();

        }

                      

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
        ResetState();
        anim.SetTrigger("kick");
        anim.SetBool("jump", false);
    }
    public void Jump()
    {
        anim.SetBool("walk", false);
        anim.SetBool("idle", false);
        anim.SetBool("jump", true);

    }



    public void ResetState()
    {
        anim.SetBool("walk", false);
        anim.SetBool("idle", false);
        anim.SetBool("jump", false);


    }
}
