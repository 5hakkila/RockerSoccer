using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_material : MonoBehaviour {

    // Use this for initialization
    public GameObject ball;
    public Material ball_material;

    public Material holomaterial ;



    // Use this for initialization
    void Start()
    {


        ball.GetComponent<MeshRenderer>().material = ball_material;
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player" )
        {

            ball.GetComponent<MeshRenderer>().material = holomaterial;
           // print("enter");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "player" )
        {

            ball.GetComponent<MeshRenderer>().material = ball_material;

           // print("exit");
        }
    }

}
