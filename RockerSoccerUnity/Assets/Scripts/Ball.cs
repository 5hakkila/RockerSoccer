using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Rigidbody2D ball;
    public Transform ballT;
    public Transform ballStart;

   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LeftGoal")
        {
            GameObject.Find("Game_Manager").GetComponent<Game_Manager>().score_Team2 += 1;
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
}
