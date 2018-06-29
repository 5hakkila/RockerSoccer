using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startpoint_move : MonoBehaviour {
    public float t = 1f; // speed
    public float l = 10f; // length from 0 to endpoint.
    public float posX = 1f; // Offset
    public Transform startPosition;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);

        Vector3 pos = new Vector3(startPosition.position.x + posX + Mathf.PingPong(t * Time.time, l) * 1.0f, startPosition.position.y, startPosition.position.z);
        transform.position = pos;


    }
}
