using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

    public enum PlayerState
    {
        LEFT,
        RIGHT,
        JUMP,
        KICK,
        SLIDE,
        IDLE
    };

    PlayerState player_state;
   
    public bool active = false;
    public Transform ball;
    public Transform player;
    public Transform start_position;
    public Rigidbody2D playerR;
    public Rigidbody2D ballR;

    private  float timer = 0.0f;
   
    private float jumpForce =0.0f;
    public bool canKick = false;
    private float kickForce = 200.0f;

    bool facingRight = true;
   
    Vector2 endDirection;
    Vector2 startDirection;
    Vector2 direction;
    public float getDistance;


  //  public bool canLaunch = true;
    // Use this for initialization
    void Start () {
        player_state = PlayerState.IDLE;
	}

    // Update is called once per frame
    void Update() {

       
        //*********************************************************************************************
        
        //ignore collision between player and ball
        Physics2D.IgnoreLayerCollision(8, 9, true);

        /*
        if (TouchControl.inputState == TouchControl.InputState.LowerRight || TouchControl.inputState == TouchControl.InputState.LowerLeft)
            { 
        Physics2D.IgnoreLayerCollision(8, 9, false);

        }
        else
            Physics2D.IgnoreLayerCollision(8, 9, true);

    */
        if (getDistance < 2.0f)
        {
            canKick = true;
        }
        if (getDistance > 2.0f)
        {
            canKick = false;
           
        }

       

        if (active == true)
        {
            Debug.Log(TouchControl.inputState);
           
            // getDistance between player and ball
            getDistance = GameObject.Find("Player_Manager").GetComponent<Player_Manager>().sendShortest;


            // Get swipe vector and normalize it***********************************************************
            endDirection = GameObject.Find("Input_Manager").GetComponent<TouchControl>().end_Position;
            startDirection = GameObject.Find("Input_Manager").GetComponent<TouchControl>().start_Position;
            direction = endDirection - startDirection;
            direction.Normalize();

            //  transform.position = Vector2.MoveTowards(player.transform.position, ball.position,2.0f *Time.deltaTime);

            if (player.transform.position.x < ball.transform.position.x && getDistance > 0.8f)
            {
                player_state = PlayerState.RIGHT;
                // playerR.velocity = new Vector2(4.0f, 0.0f);
                playerR.velocity = new Vector2(4.0f, playerR.velocity.y);

            }
            if (player.transform.position.x > ball.transform.position.x && getDistance > 0.8f)
            {
                player_state = PlayerState.LEFT;
                //    playerR.velocity = new Vector2(-4.0f, 0.0f);
                playerR.velocity = new Vector2(-4.0f, playerR.velocity.y);

            }

           
            if (TouchControl.inputState == TouchControl.InputState.Down)
            {
                print("yo");

            }

            if (TouchControl.inputState == TouchControl.InputState.UpperRight && canKick ==true)
            {

                // ballR.AddForce(direction * 1.0f * 200.0f);           
                ballR.velocity = new Vector2(0.0f, 0.0f);
                ballR.AddForce(direction * 1.0f * kickForce);
            }

            
            if (TouchControl.inputState == TouchControl.InputState.Up && canKick == true)
            {
                ballR.velocity = new Vector2(0.0f, 0.0f);
                ballR.AddForce(direction * 1.0f * kickForce);
                // ballR.AddForce(direction * 1.0f);
                //  playerR.AddForce(new Vector2(0.0f, 600.0f));
                // ballR.AddForce(direction * 1.0f  * 200.0f);     

                print("Up");
            }


            if (TouchControl.inputState == TouchControl.InputState.UpperLeft && canKick == true)
            {
                ballR.velocity = new Vector2(0.0f, 0.0f);
                ballR.AddForce(direction * 1.0f * kickForce);
                // ballR.AddForce(direction * 1.0f  * 200.0f);    

            }
            if (TouchControl.inputState == TouchControl.InputState.Left && canKick == true)
            {
                ballR.velocity = new Vector2(0.0f, 0.0f);
                ballR.AddForce(direction * 1.0f * kickForce);
                // ballR.AddForce(direction * 1.0f  * 200.0f);    

            }
            if (TouchControl.inputState == TouchControl.InputState.Right && canKick == true)
            {
                ballR.velocity = new Vector2(0.0f, 0.0f);
                ballR.AddForce(direction * 1.0f * kickForce);
                // ballR.AddForce(direction * 1.0f  * 200.0f);    

            }
        }
        else
            transform.position = Vector2.MoveTowards(player.transform.position, start_position.position, 0.1f);


        if (playerR.velocity.x > 0 && !facingRight) {

            Flip();
        }
        if (playerR.velocity.x < 0 && facingRight)
        {

            Flip();
        }
    



}
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



}
