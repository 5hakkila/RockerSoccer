using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour {
    public enum InputState
    {
        Up,
        Left,
        Right,
        Down,

        UpperRight,
        UpperLeft,
        LowerRight,
        LowerLeft,
        NoInput,
        InputStart

    };

    public static InputState inputState;

    public Vector2 start_Position; // swipe Start position
    public Vector2 end_Position; // swipe end position
 
    public  float angle;
    public float  camera_Angle;
    private float swipe_Distance_X;
    private float swipe_Distance_Y;

    private void Start()
    {
        inputState = InputState.NoInput;

    }


    void Update()
    {
      //  Debug.Log(angle);
      //  Debug.Log(swipe_Distance_X);
      //  Debug.Log(swipe_Distance_Y);
        foreach (Touch touch in Input.touches)
        {
            // start swipe
            if (touch.phase == TouchPhase.Began)
            {
                start_Position = touch.position;
                end_Position = touch.position;
               
            }
            //swipe move
            if (touch.phase == TouchPhase.Moved)
            {
                end_Position = touch.position;
                swipe_Distance_X = Mathf.Abs(end_Position.x - start_Position.x);
                swipe_Distance_Y = Mathf.Abs(end_Position.y - start_Position.y);
                //for slow mo activation
                inputState = InputState.InputStart;
                //for camera move
                camera_Angle = Mathf.Atan2((end_Position.y - start_Position.y), (end_Position.x - start_Position.x)) * 57.2957795f;

            }
            //swipe end. determine angles and assign states
            if (touch.phase == TouchPhase.Ended)
            {

                //angle = Mathf.Atan2((end_Position.x - start_Position.x),(end_Position.y - start_Position.y)) * 57.2957795f;

                angle = Mathf.Atan2((end_Position.y - start_Position.y),(end_Position.x - start_Position.x)) * 57.2957795f;

                //Right
                if (angle > -22.5f && angle < 22.50f && swipe_Distance_X > 10.0f)
                {
                   //  Debug.Log("Right");
                     inputState = InputState.Right;
                    StartCoroutine(ResetState());

                }
                //Upright
                if (angle > 22.5f && angle < 67.5f && swipe_Distance_X > 10.0f)
                {
                  //  Debug.Log("UpRight");
                    inputState = InputState.UpperRight;
                    StartCoroutine(ResetState());

                }
                //Up
                if (angle > 67.5f && angle < 112.5f && swipe_Distance_X > 10.0f)
                {
                  //  Debug.Log("Up");
                    inputState = InputState.Up;
                    StartCoroutine(ResetState());

                }
                //UpLeft
                if (angle > 112.5f && angle < 157.5f && swipe_Distance_X > 10.0f)
                {
                  //  Debug.Log("UpLeft");
                    inputState = InputState.UpperLeft;
                    StartCoroutine(ResetState());

                }
                //Left  
                if ((angle > 157.5f && angle <180.0f|| angle < -157.5f && angle > -180.0f) && swipe_Distance_X > 10.0f)
                {
                  //  Debug.Log("Left");
                    inputState = InputState.Left;
                    StartCoroutine(ResetState());

                }
                //DownLeft
                if (angle > -157.5f && angle < -112.5f && swipe_Distance_X > 10.0f)
                {
                   // Debug.Log("DownLeft");
                    inputState = InputState.LowerLeft;
                    StartCoroutine(ResetState());


                }
                //Down
                if (angle > -112.5f && angle < -67.5f && swipe_Distance_X > 10.0f)
                {
                   // Debug.Log("Down");
                    inputState = InputState.Down;
                    StartCoroutine(ResetState());

                }
                //DownRight
                if (angle > -67.5f && angle < -22.5f && swipe_Distance_X > 10.0f)
                {
                  //  Debug.Log("DownRight");
                    inputState = InputState.LowerRight;
                    StartCoroutine(ResetState());
                }
            }
        }





      //  Debug.Log(inputState);

    }


    // state goes NoInput after frame
    //basicly this mimics click
    IEnumerator ResetState()
    {
       // yield return new WaitForSeconds(0.02f);
        yield return new WaitForEndOfFrame();
        inputState = InputState.NoInput;
        
    }




}
