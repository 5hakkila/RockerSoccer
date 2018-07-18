using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Manager : MonoBehaviour
{

    public GameObject player;
    public Material[] player_material = new Material[4];
   
    public Material[] holomaterial = new Material[4];

    

    // Use this for initialization
    void Start()
    {
        player.GetComponent<CircleCollider2D>().radius = 0.0075f;
        player.GetComponent<SkinnedMeshRenderer>().materials = player_material;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player" || other.gameObject.tag == "Ball"  )
        {

            player.GetComponent<SkinnedMeshRenderer>().materials = holomaterial;
           // print("enter");

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "player" || other.gameObject.tag == "Ball" )
        {

            player.GetComponent<SkinnedMeshRenderer>().materials = holomaterial;
            // print("enter");

        }
    }





    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "player" || other.gameObject.tag == "Ball" || other.gameObject.tag == "Enemy")
        {

            player.GetComponent<SkinnedMeshRenderer>().materials = player_material;

           // print("exit");
        }
    }


}
