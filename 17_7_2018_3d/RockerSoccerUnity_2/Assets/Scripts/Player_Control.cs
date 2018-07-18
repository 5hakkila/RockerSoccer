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
   
    private float jumpForce =400.0f;
    
    public bool canKick = false;
    public float kickForce = 0.0f;
    public float extra_Force = 0.0f;


    bool facingRight = true;
   
    Vector2 endDirection;
    Vector2 startDirection;
    Vector2 direction;
    public float getDistance;
    public bool isBallPlayable = false;
    // public GameObject getInput;

    //  public bool canLaunch = true;
    //Ground check variables
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;
    public bool grounded = false;

    public float slideTimer = 0.0f;

    private bool slidingRight = false;
    private bool slidingLeft = false;

    public float swipe_Distance_x;
    public float swipe_Distance_y;
    public float swipe_Distance;

    private float ballYdistance;
    // Use this for initialization
    void Start () {
        player_state = PlayerState.IDLE;
	}

    // Update is called once per frame
    void Update() {
        extra_Force = GameObject.Find("Main Camera").GetComponent<Zoom_Out>().send_Force;

       

        //for internal access
        /*
        if (getInput.GetComponent<TouchControl>().inputState == TouchControl.InputState.Down)
        {

        }
       */
        //*********************************************************************************************
        //for testing sounds
        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            int a = 0;
            GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);

        }
        */
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerR.velocity = new Vector2(0, 0);
            playerR.AddForce(new Vector2(0, jumpForce));

        }
       
        */


        //ignore collision between player and ball
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 8, true);
        /*
        if (TouchControl.inputState == TouchControl.InputState.LowerRight || TouchControl.inputState == TouchControl.InputState.LowerLeft)
            { 
        Physics2D.IgnoreLayerCollision(8, 9, false);

        }
        else
            Physics2D.IgnoreLayerCollision(8, 9, true);

    */
        if (getDistance < 2.5f)
        {
            canKick = true;
         
        }
        if (getDistance > 2.5f)
        {
            canKick = false;
          
        }

   //     print(getDistance);





        if (active == true)
        {
            ballYdistance = player.transform.position.y + ball.transform.position.y;
            Debug.Log(ballYdistance);


            if (getDistance < 2.5f && getDistance != 0.0f)
            {
               
                GameObject.Find("Game_Manager").SendMessage("SlowMoActivate");
            }
            if (getDistance >= 2.5f && getDistance != 0.0f)
            {
               
                GameObject.Find("Game_Manager").SendMessage("SlowMoDeActivate");
            }

            //  Debug.Log(TouchControl.inputState);

            // getDistance between player and ball
            getDistance = GameObject.Find("Player_Manager").GetComponent<Player_Manager>().sendShortest;


            // Get swipe vector and normalize it***********************************************************
            endDirection = GameObject.Find("Input_Manager").GetComponent<TouchControl>().end_Position;
            startDirection = GameObject.Find("Input_Manager").GetComponent<TouchControl>().start_Position;
            direction = endDirection - startDirection;
            direction.Normalize();

            //swipe distance
            swipe_Distance_x = GameObject.Find("Input_Manager").GetComponent<TouchControl>().swipe_Distance_X;
            swipe_Distance_y = GameObject.Find("Input_Manager").GetComponent<TouchControl>().swipe_Distance_Y;
            swipe_Distance = Mathf.Sqrt(Mathf.Pow(swipe_Distance_x, 2) + Mathf.Pow(swipe_Distance_y, 2));

            kickForce = swipe_Distance / 3 + extra_Force;
            if (kickForce > 250.0f)
            {

                kickForce = 250.0f;
            }


            

            //move player right
            if (player.transform.position.x < ball.transform.position.x && getDistance > 1.0f && grounded == true && slidingLeft == false && slidingRight == false)
            {
                player_state = PlayerState.RIGHT;
                // playerR.velocity = new Vector2(4.0f, 0.0f);
                
                playerR.velocity = new Vector2(4.0f, playerR.velocity.y);
            }
            if (player.transform.position.x < ball.transform.position.x && getDistance < 1.0f && grounded == true && slidingLeft == false && slidingRight == false )
            {
                player_state = PlayerState.RIGHT;
                // playerR.velocity = new Vector2(4.0f, 0.0f);
                playerR.velocity = new Vector2(0.0f, playerR.velocity.y);


            }

            if (player.transform.position.x < ball.transform.position.x && getDistance > 1.0f && grounded == false && slidingLeft == false && slidingRight == false )
            {
                player_state = PlayerState.RIGHT;
                // playerR.velocity = new Vector2(4.0f, 0.0f);
                playerR.velocity = new Vector2(0.0f, playerR.velocity.y);
                
            }
            
             

            // move player left
            if (player.transform.position.x > ball.transform.position.x && getDistance > 1.0f && grounded == true && slidingLeft ==false && slidingRight == false )
            {
                player_state = PlayerState.LEFT;
                          
                //    playerR.velocity = new Vector2(-4.0f, 0.0f);
                playerR.velocity = new Vector2(-4.0f, playerR.velocity.y);
               

            }
            if (player.transform.position.x > ball.transform.position.x && getDistance < 1.0f && grounded == true && slidingLeft == false && slidingRight == false )
            {
                player_state = PlayerState.LEFT;
                //    playerR.velocity = new Vector2(-4.0f, 0.0f);
                playerR.velocity = new Vector2(0.0f, playerR.velocity.y);


            }
            if (player.transform.position.x > ball.transform.position.x && getDistance > 1.0f && grounded == false && slidingLeft == false && slidingRight == false)
            {
                player_state = PlayerState.LEFT;
                //    playerR.velocity = new Vector2(-4.0f, 0.0f);
                playerR.velocity = new Vector2(0.0f, playerR.velocity.y);

            }

            if (player.transform.position.x - ball.transform.position.x < 0.2f
                && getDistance > 1.0f && grounded == false && slidingLeft == false && slidingRight == false)
            {
                
                playerR.velocity = new Vector2(0.0f, playerR.velocity.y);

            }




            if (TouchControl.inputState == TouchControl.InputState.Down && canKick == true && isBallPlayable == true && grounded == true && slidingLeft == false && slidingRight == false)
            {

                GameObject.Find("Ball").SendMessage("StopBall");
            }

            



            //jump
            if (TouchControl.inputState == TouchControl.InputState.Up && canKick == false && isBallPlayable == true && grounded == true && slidingLeft == false && slidingRight == false)
            {
                playerR.velocity = new Vector2(0, 0);
                playerR.AddForce(new Vector2(0, jumpForce));
                //sound
                int a = 1;
                GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);


            }
            //slide
            if (TouchControl.inputState == TouchControl.InputState.LowerRight && canKick == false && isBallPlayable == true && grounded == true && slideTimer == 0.0f )
            {
                slidingRight = true;
               

            }

            if (TouchControl.inputState == TouchControl.InputState.LowerLeft && canKick == false && isBallPlayable == true && grounded == true && slideTimer == 0.0f)
            {

                slidingLeft = true;

            }

            if (slidingRight ==true)
            {
                slideTimer += 1.0f * Time.deltaTime;
                if (slideTimer < 0.1f)
                {
                    playerR.velocity = new Vector2(22, playerR.velocity.y);
                }

            }
            if (slidingLeft == true)
            {
                slideTimer += 1.0f * Time.deltaTime;
                if (slideTimer < 0.1f)
                {
                    playerR.velocity = new Vector2(-22, playerR.velocity.y);
                }

            }
            if (slideTimer > 0.2f)
            {
                slidingLeft = false;
                slidingRight = false;
                
            }
            if (slideTimer > 2.2f)
            {

                 slideTimer = 0.0f;
            }
            //slide kick
            if (slidingRight == true && facingRight ==true && canKick == true)
            {
                ballR.velocity = new Vector2(0.0f, 0.0f);
                ballR.AddForce(new Vector2(1.0f, 0.0f) * 250.0f);

                int a = 0;
                GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);

            }
            if (slidingLeft == true && facingRight == false && canKick == true)
            {
                ballR.velocity = new Vector2(0.0f, 0.0f);
                ballR.AddForce(new Vector2(-1.0f, 0.0f) * 250.0f);

                int a = 0;
                GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);

            }


            //kick ball start*******************************************************************************************************************
            if (TouchControl.inputState == TouchControl.InputState.UpperRight && canKick == true && isBallPlayable == true && grounded == true)
            {
                // swipe_Distance = Mathf.Sqrt(Mathf.Pow(GameObject.Find("Input_Manager").GetComponent<TouchControl>().swipe_Distance_X), 2.0f);



                //getDistance = GameObject.Find("Ai_Manager").GetComponent<Ai_Manager>().sendShortest;
                if (GameObject.Find("Ball").GetComponent<Ball>().grounded == true)
                {
                    ballR.velocity = new Vector2(0.0f, 0.0f);
                    ballR.AddForce(direction * 1.0f * kickForce);

                    int a = 0;
                    GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);

                }
            }


            if (TouchControl.inputState == TouchControl.InputState.Up && canKick == true && isBallPlayable == true && grounded == true)
            {
                if (GameObject.Find("Ball").GetComponent<Ball>().grounded == true)
                {
                    ballR.velocity = new Vector2(0.0f, 0.0f);
                    ballR.AddForce(direction * 1.0f * kickForce);

                    int a = 0;
                    GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);

                }

            }


            if (TouchControl.inputState == TouchControl.InputState.UpperLeft && canKick == true && isBallPlayable == true && grounded == true)
            {
                if (GameObject.Find("Ball").GetComponent<Ball>().grounded == true)
                {
                    ballR.velocity = new Vector2(0.0f, 0.0f);
                    ballR.AddForce(direction * 1.0f * kickForce);

                    int a = 0;
                    GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);

                }

            }

            if (TouchControl.inputState == TouchControl.InputState.Left && canKick == true && isBallPlayable == true && grounded == true)
            {
                if (GameObject.Find("Ball").GetComponent<Ball>().grounded == true)
                {
                    ballR.velocity = new Vector2(0.0f, 0.0f);
                    ballR.AddForce(direction * 1.0f * kickForce);

                    int a = 0;
                    GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);

                }


            }

            if (TouchControl.inputState == TouchControl.InputState.Right && canKick == true && isBallPlayable == true && grounded == true)
            {
                if (GameObject.Find("Ball").GetComponent<Ball>().grounded == true)
                {
                    ballR.velocity = new Vector2(0.0f, 0.0f);
                    ballR.AddForce(direction * 1.0f * kickForce);

                    int a = 0;
                    GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);

                }

            }
            // kick ball end *******************************************************************************************************************

            //on air kick header

            /*
            if (canKick == true && isBallPlayable == true && grounded == false)
            {
                if (GameObject.Find("Ball").GetComponent<Ball>().grounded == false && TouchControl.inputState != TouchControl.InputState.NoInput)
                { 
                  //  ballR.velocity = new Vector2(0.0f, 0.0f);
                    ballR.AddForce(direction * 1.0f * (kickForce /1.5f));

                    int a = 0;
                    GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);


                }
            }
            */
            if (canKick == true && isBallPlayable == true && grounded == false)
            {
                if (GameObject.Find("Ball").GetComponent<Ball>().grounded == false && TouchControl.inputState == TouchControl.InputState.NoInput)
                {
                    //  ballR.velocity = new Vector2(0.0f, 0.0f);
                    //  ballR.AddForce(direction * 1.0f * (kickForce / 1.5f));
                    if (facingRight ==true) {
                        ballR.velocity = new Vector2(0.0f, 0.0f);
                        ballR.AddForce(new Vector2(1.0f, 0.0f) * 200.0f);

                        int a = 0;
                        GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);
                    }
                    if (facingRight == false)
                    {
                        ballR.velocity = new Vector2(0.0f, 0.0f);
                        ballR.AddForce(new Vector2(1.0f, 0.0f) * -200.0f);

                        int a = 0;
                        GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);
                    }



                }
            }





        }
        // move back to staring position
        if (active == false && grounded ==true)
        {
            transform.position = Vector2.MoveTowards(player.transform.position, start_position.position, 0.1f);
            slideTimer = 0.0f;

           
        }

        //flip player direction
        if (playerR.velocity.x > 0 && !facingRight && Mathf.Abs(player.transform.position.x - ball.transform.position.x) > 0.1f)
        {

            Flip();
        }
        if (playerR.velocity.x < 0 && facingRight && Mathf.Abs(player.transform.position.x - ball.transform.position.x) > 0.1f)
        {

            Flip();
        }
    



}
    private void FixedUpdate()
    {
        //Ground check
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void EnableBall()
    {
        isBallPlayable = true;

    }
    public void DisableBall()
    {
        isBallPlayable = false;

    }

    


}
