using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {

    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimunLogoTime = 3.0f;

    private void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1.0f;

        if (Time.time < minimunLogoTime)
            loadTime = minimunLogoTime;
        else loadTime = Time.time;
    }

    private void Update()
    {
        if(Time.time < minimunLogoTime)
        {
            fadeGroup.alpha =  1 - Time.time;
        }

        if(Time.time > minimunLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimunLogoTime;
            if(fadeGroup.alpha >= 1)
            {
                Debug.Log("Change the scene");
                SceneManager.LoadScene("Menu");
            }
        }

    }

}
