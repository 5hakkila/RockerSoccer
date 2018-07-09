using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;



public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider sfxSlider;
    public Slider musicSlider;
    
   

    float savedMusicVolume;
    bool changed = false;
 


   


    public void Awake()
    {

        //Tallennetut ääniasetukset
    
        savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume");


        //Asetetaan tallennetut arvot
    

            audioMixer.SetFloat("MusicVolume", savedMusicVolume);
            musicSlider.value = savedMusicVolume;

    
      

    }

    private void Update()
    {

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
     
       
        
        
       
    }



    public void SetMasterVolume (float MasterVolume)
    {
        audioMixer.SetFloat("MasterVolume", MasterVolume);
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
      
    }

    public void SetSFXVolume(float SFXVolume)
    {  
      //  audioMixer.SetFloat("SFXVolume", SFXVolume);    
      //PlayerPrefs.SetFloat("SFXVolume", savedSFXVolume);
        
    }


    public void SetMusicVolume(float MusicVolume)
    {


        if (MusicVolume == 0)
        {
            MusicVolume = -20;
            audioMixer.SetFloat("MusicVolume", MusicVolume);
            musicSlider.value = MusicVolume;
           
        }
        else if(MusicVolume != 0)
        {
            PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
            musicSlider.value = MusicVolume;
        }

       
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
