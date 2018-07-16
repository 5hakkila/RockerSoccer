using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayingTime : MonoBehaviour {

    GameObject playTimeSlider;
    public Text playTimeText;
    float playTime;
    float value;
    float roundedPlayTime;
    private void Awake()
    {
        playTimeSlider = GameObject.Find("PlayTimeSlider");
        playTime = playTimeSlider.GetComponent<Slider>().value;
        playTimeText.text = playTime + " seconds";
       
        
    }
    private void Update()
    {

       
        playTime = playTimeSlider.GetComponent<Slider>().value;
        roundedPlayTime = Mathf.Round(playTime);
        playTimeText.text = roundedPlayTime + " seconds";
        PlayerPrefs.SetFloat("PlayTime", roundedPlayTime);


       // Debug.Log(playTime);
    }

  
}
