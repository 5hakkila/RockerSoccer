
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider sfxSlider;
    public Slider musicSlider;

   
    float savedSFXVolume;
    float savedMusicVolume;

    



    private void Start()
    {

        musicSlider.normalizedValue = -50;
  
        
        //Tallennetut ääniasetukset
        savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume");


        //Asetetaan tallennetut arvot
        audioMixer.SetFloat("SFXVolume", savedSFXVolume);
        audioMixer.SetFloat("MusicVolume", savedMusicVolume);  


    }


    public void SetMasterVolume (float MasterVolume)
    {
        audioMixer.SetFloat("MasterVolume", MasterVolume);
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
        PlayerPrefs.Save();   
    }

    public void SetSFXVolume(float SFXVolume)
    {  
        audioMixer.SetFloat("SFXVolume", SFXVolume);    
        PlayerPrefs.SetFloat("SFXVolume", savedSFXVolume);
        PlayerPrefs.Save();
    }


    public void SetMusicVolume(float MusicVolume)
    {
        audioMixer.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        Debug.Log(PlayerPrefs.GetFloat("MusicVolume"));
       

       
        PlayerPrefs.Save();
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
