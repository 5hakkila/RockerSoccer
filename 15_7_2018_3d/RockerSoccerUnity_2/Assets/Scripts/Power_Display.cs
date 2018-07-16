using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Display : MonoBehaviour {

    public Transform lineStart;
    private Vector3 lineEnd;

    public Transform arrow;

    private float line_Angle;
  //  private float power;

    private float swipe_Distance_x;
    private float swipe_Distance_y;
    private float swipe_Distance;

    private Vector2 direction;
    public GameObject myLine;
    private Vector2 end_Pos;
    private Vector2 start_Pos;
    private float angle;

   // private float extra_Distance = 0.0f;

    private Vector2 arrow_Angle;
    public Color c1 = Color.green;
    public Color c2 = Color.red;
    // Use this for initialization

    public bool activate = false;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //extra_Distance = GameObject.Find("Main Camera").GetComponent<Zoom_Out>().send_Force;

        line_Angle = GameObject.Find("Input_Manager").GetComponent<TouchControl>().camera_Angle;

            swipe_Distance_x = GameObject.Find("Input_Manager").GetComponent<TouchControl>().swipe_Distance_X;
            swipe_Distance_y = GameObject.Find("Input_Manager").GetComponent<TouchControl>().swipe_Distance_Y;
            swipe_Distance = Mathf.Sqrt(Mathf.Pow(swipe_Distance_x, 2) + Mathf.Pow(swipe_Distance_y, 2)) / 300;

            end_Pos = GameObject.Find("Input_Manager").GetComponent<TouchControl>().end_Position;

            start_Pos = GameObject.Find("Input_Manager").GetComponent<TouchControl>().start_Position;

       if( GameObject.Find("Input_Manager").GetComponent<TouchControl>().end == true)
        {
            activate = false;
            GameObject.Find("arrow").GetComponent<SpriteRenderer>().enabled = false;
        }


            direction = (end_Pos - start_Pos) / 100 ;
            
            arrow_Angle = end_Pos - start_Pos;

            
            

            arrow.position = new Vector3((lineStart.position.x + direction.x), (lineStart.position.y + direction.y), 0.0f);


            angle = Mathf.Atan2((end_Pos.y - start_Pos.y), (end_Pos.x - start_Pos.x)) * 57.2957795f;

            arrow.eulerAngles = new Vector3(0.0f, 0.0f, angle);


            


        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        // lineRenderer.sortingLayerName = "Foreground";
        lineRenderer.SetPosition(0, new Vector3(lineStart.position.x, lineStart.position.y, 0.0f));

        lineRenderer.SetPosition(1, new Vector3((lineStart.position.x + direction.x), (lineStart.position.y + direction.y), 0.0f));

        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;

        if (activate ==true)
        {
            lineRenderer.enabled = true;
        }
        if (activate ==false)
        {
            lineRenderer.enabled = false;
        }
    }


    public void EnableDisplay()
    {
        activate = true;
        
        
    }
    public void DisableDisplay()
    {
        activate = false;
       
       
    }


}
