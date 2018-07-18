using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_rotate : MonoBehaviour {
    public Rigidbody2D ball;
    private float horizontalSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        horizontalSpeed = ball.velocity.x;


        if (horizontalSpeed != 0.0f)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * (horizontalSpeed * -20.0f), Space.World);
        }
    }
}
