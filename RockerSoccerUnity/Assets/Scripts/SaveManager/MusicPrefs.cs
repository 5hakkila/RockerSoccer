using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPrefs : MonoBehaviour {

    private bool mute;
    AudioSource aS;

	// Use this for initialization
	void Start () {
        aS = GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            aS.volume = PlayerPrefs.GetFloat("musicVolume");
        }
	}
	

}
