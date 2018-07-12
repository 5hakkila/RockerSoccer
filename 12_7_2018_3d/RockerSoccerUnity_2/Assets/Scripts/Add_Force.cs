using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Force : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D ball;
    public Transform ballT;
    public Transform ballStart;
    float myAngle;
    public float timer = 0.0f;
    Vector2 endDirection;
    Vector2 startDirection;
    Vector2 direction;

    public float b_distance;
    public bool grounded = false;
    public bool canLaunch = false;
    private float kickForce = 200.0f;
    void Start() {





    }

    // Update is called once per frame
    void Update()
    {
        b_distance = GameObject.Find("Player_Manager").GetComponent<Player_Manager>().sendShortest;
        // Debug.Log(direction * 1.3f);

        myAngle = GameObject.Find("Input_Manager").GetComponent<TouchControl>().angle;
        endDirection = GameObject.Find("Input_Manager").GetComponent<TouchControl>().end_Position;
        startDirection = GameObject.Find("Input_Manager").GetComponent<TouchControl>().start_Position;
        direction = endDirection - startDirection;
        direction.Normalize();

        if (TouchControl.inputState == TouchControl.InputState.UpperRight && grounded == true && canLaunch == true)
        {
            timer += 1.0f * Time.deltaTime;
            ball.velocity = new Vector2(0.0f, 0.0f);
            ball.AddForce(direction * 1.0f * kickForce);


            if (timer < 0.03f)
            {
                // ball.AddForce(new Vector2(Mathf.Cos(myAngle), Mathf.Sin(myAngle)) * 300.0f);



            }
        }
           
        if (TouchControl.inputState == TouchControl.InputState.Up && grounded == true && canLaunch == true)
        {
           
                ball.velocity = new Vector2(0.0f, 0.0f);
                ball.AddForce(direction * 1.0f * kickForce);
                      
        }
           
        if (TouchControl.inputState == TouchControl.InputState.UpperLeft && grounded == true && canLaunch == true)
            {
            
                ball.velocity = new Vector2(0.0f, 0.0f);
                ball.AddForce(direction * 1.0f * kickForce);    
            
        }

        if (TouchControl.inputState == TouchControl.InputState.Left && grounded == true && canLaunch == true)
        {
            
            ball.velocity = new Vector2(0.0f, 0.0f);
            ball.AddForce(direction * 1.0f * kickForce);
            
        }

        if (TouchControl.inputState == TouchControl.InputState.Right && grounded == true && canLaunch == true)
        {
            
            ball.velocity = new Vector2(0.0f, 0.0f);
            ball.AddForce(direction * 1.0f * kickForce);
            
        }

        if (TouchControl.inputState == TouchControl.InputState.Down)
        {
            

        }

        // determine distance player can kick the ball
        if (b_distance < 2.0f)
        {
            canLaunch = true;
        }
        if (b_distance > 2.0f)
        {
            canLaunch = false;
            //timer = 0.0f;
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
           

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
           
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="LeftGoal")
        {
            GameObject.Find("Game_Manager").GetComponent<Game_Manager>().score_Team2 +=1;
            ballT.transform.position = ballStart.transform.position;
            ball.velocity = new Vector2(0.0f, 0.0f);
            // Debug.Log("detected enter");
            // canLaunch = true;
            //  Physics2D.IgnoreLayerCollision(8, 9, true);
        }
        if (other.gameObject.tag == "RightGoal")
        {
            GameObject.Find("Game_Manager").GetComponent<Game_Manager>().score_Team1 += 1;
            ballT.transform.position = ballStart.transform.position;
            ball.velocity = new Vector2(0.0f, 0.0f);
            // Debug.Log("detected enter");
            // canLaunch = true;
            //  Physics2D.IgnoreLayerCollision(8, 9, true);
        }

    }

    
    /*
     * 
     * 
     * 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canLaunch = false;
            Debug.Log("detected exit");
            timer = 0.0f;
            //  Physics2D.IgnoreLayerCollision(8, 9, true);
        }


    }

*/
}
