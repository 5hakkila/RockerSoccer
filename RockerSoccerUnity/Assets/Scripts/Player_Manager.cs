using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class Player_Manager : MonoBehaviour {

    public enum Selected
    {
        Player1,
        Player2,
        Player3,
        Player4,
        Player5
    };
    
    public Transform[] players;
    public Transform ball;
    public Selected selected;
       
    public float[] player_array = new float[5];

    public float sendShortest;
    int minIndex;
    // Use this for initialization
    void Start() {

       
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
            GameObject.Find("Player_5").GetComponent<Player_Control>().active = true;
        }
        else
            GameObject.Find("Player_5").GetComponent<Player_Control>().active = false;

        //find index of min distance
         minIndex = Array.IndexOf(player_array, player_array.Min());

        // select player state based on index
        if (minIndex == 0) { selected = Selected.Player1; }
        if (minIndex == 1) { selected = Selected.Player2; }
        if (minIndex == 2) { selected = Selected.Player3; }
        if (minIndex == 3) { selected = Selected.Player4; }
        if (minIndex == 4) { selected = Selected.Player5; }




    }

      

   


}
