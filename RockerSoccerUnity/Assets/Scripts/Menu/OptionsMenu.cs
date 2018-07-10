using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;



public class OptionsMenu : MonoBehaviour
{

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


        musicSlider.value = savedMusicVolume;
        audioMixer.SetFloat("MusicVolume", savedMusicVolume);




    }

    private void Update()
    {

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");





    }



    public void SetMasterVolume(float MasterVolume)
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

        {

            audioMixer.SetFloat("MusicVolume", MusicVolume);

            PlayerPrefs.SetFloat("MusicVolume", MusicVolume);



        }

        /* public void SetQuality (int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);

            } */
    }

}

