using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_SFX : MonoBehaviour {


    public AudioClip[] clipHolder;
    AudioSource audioData;
    // Use this for initialization
    void Start () {
        audioData = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayClip(int a)
    {
        if (!audioData.isPlaying)
        {


            audioData.clip = clipHolder[a];
            audioData.Play();

        }
    }


}
