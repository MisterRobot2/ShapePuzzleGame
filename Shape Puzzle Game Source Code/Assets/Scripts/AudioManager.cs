using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource audio;

	// Use this for initialization
	void Start ()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        audio.volume = CurrentData.gameData.volume;
    }
}
