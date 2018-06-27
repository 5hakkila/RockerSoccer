using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Out : MonoBehaviour {

    public new Transform  camera;
    
    public float distance;

    public Camera m_OrthographicCamera;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (camera.transform.position.y > 0)
        {
            m_OrthographicCamera.orthographicSize  = 4 +  camera.transform.position.y ;

        }



    }
}
