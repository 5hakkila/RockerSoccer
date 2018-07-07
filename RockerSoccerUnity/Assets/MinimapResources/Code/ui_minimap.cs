using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_minimap : MonoBehaviour {


    public Transform startLocation;
    public Transform endLocation;
    public GameObject GenericMarker;
    float Distance_;
    public static string[] tagArray = { "player", "Enemy" };
    public static Color[] colorArray = { Color.green, Color.red };
    private GameObject[][] Objects = new GameObject[5][];
    //^Holy shit^




    // Use this for initialization
    void Start()
    {

        startLocation = transform.Find("MinMap_Start");
        endLocation = transform.Find("MinMap_End");


        Distance_ = Vector2.Distance(startLocation.position, endLocation.position);

        //new prototype
        for (int i = 0; i < tagArray.Length; i++)
        {
            //Makes a temporal array of required gameobjects
            Objects[i] = GameObject.FindGameObjectsWithTag(tagArray[i]);

            //Spawn a marker for all objects in the temp. array
            for (int u = 0; u < Objects[i].Length; u++)
            {
                GameObject mark = (GameObject)Instantiate(GenericMarker, GameObject.Find("Background").transform.position, transform.rotation);
                mark.transform.SetParent(GameObject.Find("Background").transform);
                mark.name = tagArray[i] + "_mark" + u;
                mark.GetComponent<Image>().color = colorArray[i];

            }
        }



        /*
        PlayerArray = GameObject.FindGameObjectsWithTag("Player");
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        //Spawn a marker for objects tagged as "Player"
        for (int i = 0; i < PlayerArray.Length; i++)
        {
            GameObject Player_mark = (GameObject)Instantiate(PlayerMarker, GameObject.Find("Background").transform.position, transform.rotation);
            Player_mark.transform.parent = GameObject.Find("Background").transform;
            Player_mark.name = "Player_mark" + i;

        }


        //Spawn a marker for objects tagged as "Enemy"
        for (int i = 0; i < EnemyArray.Length; i++)
        {
            GameObject Enemy_mark = (GameObject)Instantiate(EnemyMarker, GameObject.Find("Background").transform.position, transform.rotation);
            Enemy_mark.transform.parent = GameObject.Find("Background").transform;
            Enemy_mark.name = "Enemy_mark" + i;

        }

     */

    }


    // Update is called like 60 times a second lmao
    void FixedUpdate()
    {

        for (int i = 0; i < tagArray.Length; i++)
        {


            float objRelativeLoc;

            for (int u = 0; u < Objects[i].Length; u++)
            {
                if (Objects[i][u] != null)
                {
                    if (startLocation.position.x < 0)
                    {
                        objRelativeLoc = (Objects[i][u].transform.position.x - startLocation.position.x) / Distance_ * 100;
                    }
                    else
                    {
                        objRelativeLoc = (Objects[i][u].transform.position.x + startLocation.position.x) / Distance_ * 100;
                    }
                    if (Objects[i][u] != null)
                    {

                            GameObject.Find(tagArray[i] + "_mark" + u).GetComponent<PlayerDotSetter>().SetTransformX(objRelativeLoc);
                    }

                }
                else if (Objects[i][u] == null)
                {
                    //This should delete the marker if the object is missing
                    Destroy(GameObject.Find(tagArray[i] + "_mark" + u));

                }
                else
                {
                    Debug.Log("Somthing went \"BOOM!\"");
                    //The fuck???
                }


                /*
                for (int i = 0; i < EnemyArray.Length; i++)
                {
                    float objRelativeLoc;

                    if (EnemyArray[i] != null)
                    {

                        if (startLocation.position.x < 0)
                        {
                            objRelativeLoc = (EnemyArray[i].transform.position.x - startLocation.position.x) / Distance_ * 100;
                        }
                        else
                        {
                            objRelativeLoc = (EnemyArray[i].transform.position.x + startLocation.position.x) / Distance_ * 100;
                        }
                        GameObject.Find("Enemy_mark" + i).GetComponent<PlayerDotSetter>().SetTransformX(objRelativeLoc);
                    }
                    else
                    {
                        Destroy(GameObject.Find("Enemy_mark" + i));
                    }
                }
                */

            }



        }
    }
    //Use this function to refresh the list of objects that need to be tracked by the minimap
    public void minimapRefresh()
    {

        for (int i = 0; i < tagArray.Length; i++)
        {
            Objects[i] = GameObject.FindGameObjectsWithTag(tagArray[i]);


            for (int u = 0; u < Objects[i].Length; u++)
            {
                if (GameObject.Find(tagArray[i] + "_mark" + u) != null)
                {
                    //The object of number i already exists
                }
                else
                {
                    GameObject mark = (GameObject)Instantiate(GenericMarker, GameObject.Find("Background").transform.position, transform.rotation);
                    mark.transform.SetParent(GameObject.Find("Background").transform);
                    mark.name = tagArray[i] + "_mark" + u;
                    mark.GetComponent<Image>().color = colorArray[i];
                    Objects[i] = GameObject.FindGameObjectsWithTag(tagArray[i]);

                }
            }


        }
    }
}

    