using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

using UnityEngine.UI;

public class Player_Manager : MonoBehaviour {

    public enum Selected
    {
        Player1,
        Player2,
        Player3,
        Player4,
        Player5
    };


    public Image marker;
    public Transform[] players;
    public Transform ball;
    public Selected selected;
       
    public float[] player_array = new float[5];

    public float sendShortest;
    int minIndex;

    public bool isBallDisabled = false;
    // Use this for initialization
    void Start() {

        marker = GameObject.Find("marker").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update() {
        // sending distance to other scripts
        sendShortest = player_array[minIndex];

        //measure players distance to ball
        for (int i = 0; i < 5; i++)
        {               
            player_array[i] = Vector2.Distance(players[i].transform.position, ball.transform.position);
        }




        if (GameObject.Find("Game_Manager").GetComponent<Game_Manager>().releaseBall == true && isBallDisabled ==false)
        {
            // activate selected player and deactivate others
            if (selected == Selected.Player1)
            {

                GameObject.Find("Player_1").GetComponent<Player_Control>().active = true;
            }
            else
                GameObject.Find("Player_1").GetComponent<Player_Control>().active = false;

            if (selected == Selected.Player2)
            {
                GameObject.Find("Player_2").GetComponent<Player_Control>().active = true;
            }
            else
                GameObject.Find("Player_2").GetComponent<Player_Control>().active = false;

            if (selected == Selected.Player3)
            {
                GameObject.Find("Player_3").GetComponent<Player_Control>().active = true;
            }
            else
                GameObject.Find("Player_3").GetComponent<Player_Control>().active = false;

            if (selected == Selected.Player4)
            {
                GameObject.Find("Player_4").GetComponent<Player_Control>().active = true;
            }
            else
                GameObject.Find("Player_4").GetComponent<Player_Control>().active = false;

            if (selected == Selected.Player5)
            {
                GameObject.Find("Player_5").GetComponent<Player_Goalkeeper>().active = true;
            }
            else
                GameObject.Find("Player_5").GetComponent<Player_Goalkeeper>().active = false;

            //find index of min distance
            minIndex = Array.IndexOf(player_array, player_array.Min());

            if (GameObject.Find("Game_Manager").GetComponent<Game_Manager>().releaseBall == true)
            {
                marker.GetComponent<Transform>().transform.position = players[minIndex].transform.position;

                marker.GetComponent<Transform>().Translate(0, 10, 0);
             
            }
            
           
                
            



            // select player state based on index
            if (minIndex == 0) { selected = Selected.Player1; }
            if (minIndex == 1) { selected = Selected.Player2; }
            if (minIndex == 2) { selected = Selected.Player3; }
            if (minIndex == 3) { selected = Selected.Player4; }
            if (minIndex == 4) { selected = Selected.Player5; }


        }
        if (GameObject.Find("Game_Manager").GetComponent<Game_Manager>().releaseBall == false )
        {
            GameObject.Find("Player_1").GetComponent<Player_Control>().active = false;
            GameObject.Find("Player_2").GetComponent<Player_Control>().active = false;
            GameObject.Find("Player_3").GetComponent<Player_Control>().active = false;
            GameObject.Find("Player_4").GetComponent<Player_Control>().active = false;
            GameObject.Find("Player_5").GetComponent<Player_Goalkeeper>().active = false;
        }

        if (isBallDisabled == true)
        {
            GameObject.Find("Player_1").GetComponent<Player_Control>().active = false;
            GameObject.Find("Player_2").GetComponent<Player_Control>().active = false;
            GameObject.Find("Player_3").GetComponent<Player_Control>().active = false;
            GameObject.Find("Player_4").GetComponent<Player_Control>().active = false;
            GameObject.Find("Player_5").GetComponent<Player_Goalkeeper>().active = false;

        }


    }

      

   


}
