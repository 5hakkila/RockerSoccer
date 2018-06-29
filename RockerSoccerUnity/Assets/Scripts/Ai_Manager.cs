using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class Ai_Manager : MonoBehaviour {
    public enum Selected
    {
       AI_1,
       AI_2,
       AI_3,
       AI_4,
       AI_5
    };

    public Transform[] ai_array_T;
    public Transform ball;
    public Selected selected;

    public float[] ai_array_D = new float[5];

    public float sendShortest;
    int minIndex;
    public bool isBallDisabled = false;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // sending distance to other scripts
        sendShortest =ai_array_D[minIndex];

        //measure players distance to ball
        for (int i = 0; i < 5; i++)
        {
            ai_array_D[i] = Vector2.Distance(ai_array_T[i].transform.position, ball.transform.position);
        }


        if (GameObject.Find("Game_Manager").GetComponent<Game_Manager>().releaseBall == true && isBallDisabled == false)
        {

            // activate selected player and deactivate others
            if (selected == Selected.AI_1)
            {

                GameObject.Find("Ai_1").GetComponent<Basic_Ai>().active = true;
            }
            else
                GameObject.Find("Ai_1").GetComponent<Basic_Ai>().active = false;

            if (selected == Selected.AI_2)
            {
                GameObject.Find("Ai_2").GetComponent<Basic_Ai>().active = true;
            }
            else
                GameObject.Find("Ai_2").GetComponent<Basic_Ai>().active = false;

            if (selected == Selected.AI_3)
            {
                GameObject.Find("Ai_3").GetComponent<Basic_Ai>().active = true;
            }
            else
                GameObject.Find("Ai_3").GetComponent<Basic_Ai>().active = false;

            if (selected == Selected.AI_4)
            {
                GameObject.Find("Ai_4").GetComponent<Basic_Ai>().active = true;
            }
            else
                GameObject.Find("Ai_4").GetComponent<Basic_Ai>().active = false;

            if (selected == Selected.AI_5)
            {
                GameObject.Find("Ai_5").GetComponent<Basic_Ai>().active = true;
            }
            else
                GameObject.Find("Ai_5").GetComponent<Basic_Ai>().active = false;

            //find index of min distance
            minIndex = Array.IndexOf(ai_array_D, ai_array_D.Min());

            // select player state based on index
            if (minIndex == 0) { selected = Selected.AI_1; }
            if (minIndex == 1) { selected = Selected.AI_2; }
            if (minIndex == 2) { selected = Selected.AI_3; }
            if (minIndex == 3) { selected = Selected.AI_4; }
            if (minIndex == 4) { selected = Selected.AI_5; }



        }
        if (GameObject.Find("Game_Manager").GetComponent<Game_Manager>().releaseBall == false)
        {
            GameObject.Find("Ai_1").GetComponent<Basic_Ai>().active = false;
            GameObject.Find("Ai_2").GetComponent<Basic_Ai>().active = false;
            GameObject.Find("Ai_3").GetComponent<Basic_Ai>().active = false;
            GameObject.Find("Ai_4").GetComponent<Basic_Ai>().active = false;
            GameObject.Find("Ai_5").GetComponent<Basic_Ai>().active = false;



        }
        if (isBallDisabled == true)
        {
            GameObject.Find("Ai_1").GetComponent<Basic_Ai>().active = false;
            GameObject.Find("Ai_2").GetComponent<Basic_Ai>().active = false;
            GameObject.Find("Ai_3").GetComponent<Basic_Ai>().active = false;
            GameObject.Find("Ai_4").GetComponent<Basic_Ai>().active = false;
            GameObject.Find("Ai_5").GetComponent<Basic_Ai>().active = false;



        }

    }





}
