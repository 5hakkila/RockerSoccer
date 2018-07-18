using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Ai : MonoBehaviour {

    public bool active = false;
    public Transform ball;
    public Transform opponentT;
    public Transform start_position;
    public Rigidbody2D opponentR;
    public Rigidbody2D ballR;

    public GameObject AnimationObject;
      
    public bool canKick = false;
    public bool kicked = false; // no action currently
    private int kickTimer = 0; // basicly bool to stop multiple kicks
    private float kickForce = 200.0f;

    bool facingRight = true;

    Vector2 endDirection;
    Vector2 startDirection;
    Vector2 direction;
    public float getDistance;
    public bool isBallPlayable = false;
   
    //  public bool canLaunch = true;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


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



        if (active == true)
        {
            
            
            // getDistance between player and ball
            getDistance = GameObject.Find("Ai_Manager").GetComponent<Ai_Manager>().sendShortest;
          //  Debug.Log(getDistance);

            if (getDistance < 2.5f && getDistance != 0.0f)
            {
               
                StartCoroutine(Kick());
               
            }
            if (getDistance > 2.5f)
            {
                canKick = false;
                kickTimer = 0;
            }
            //slide


            


            //  transform.position = Vector2.MoveTowards(player.transform.position, ball.position,2.0f *Time.deltaTime);
            //move
            if (opponentT.transform.position.x < ball.transform.position.x && getDistance > 1.0f )
            {
               
               
                opponentR.velocity = new Vector2(4.0f, opponentR.velocity.y);

            }
            if (opponentT.transform.position.x < ball.transform.position.x && getDistance < 1.0f)
            {


                opponentR.velocity = new Vector2(0.0f, opponentR.velocity.y);

            }


            if (opponentT.transform.position.x > ball.transform.position.x && getDistance > 1.0f)
            {
                
               
                opponentR.velocity = new Vector2(-4.0f, opponentR.velocity.y);

            }
            if (opponentT.transform.position.x > ball.transform.position.x && getDistance < 1.0f)
            {


                opponentR.velocity = new Vector2(-0.0f, opponentR.velocity.y);

            }

            if (opponentT.transform.position.x - ball.transform.position.x < 0.2f && getDistance < 1.0f)
            {


                opponentR.velocity = new Vector2(-0.0f, opponentR.velocity.y);

            }





            if (canKick ==true && getDistance < 2.0f && isBallPlayable == true )
            {
                if (kickTimer ==0) {
                    Vector2 direction = new Vector2(Random.Range(-10.0f, 0.0f), Random.Range(10.0f, 0.0f));
                    direction.Normalize();

                    ballR.velocity = new Vector2(0.0f, 0.0f);
                    ballR.AddForce(direction * 1.0f * Random.Range(130.0f,300.0f));
                    int a = 0;
                    GameObject.Find("Audio_Manager").SendMessage("PlayClip", a);
                    AnimationObject.GetComponent<Ai_Animation>().Kick();
                    kickTimer += 1;

                }
            }



          
        }
        else
            transform.position = Vector2.MoveTowards(opponentT.transform.position, start_position.position, 0.1f);


        if (opponentR.velocity.x > 0 && !facingRight && Mathf.Abs(opponentT.transform.position.x - ball.transform.position.x) > 0.1f)
        {

            Flip();
        }
        if (opponentR.velocity.x < 0 && facingRight && Mathf.Abs(opponentT.transform.position.x - ball.transform.position.x) > 0.1f)
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



    IEnumerator Kick()
    {
        
        canKick = true;
        yield return new WaitForEndOfFrame();
        canKick = false;
       
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
