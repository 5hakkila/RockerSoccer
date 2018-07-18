using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDotSetter : MonoBehaviour {



    public void SetTransformX(float n)
    {
        //Position shall be the pivot of the background + the number we receive:
        transform.position = new Vector3(GameObject.Find("Background").transform.position.x + n, transform.position.y);

    }

   
}
