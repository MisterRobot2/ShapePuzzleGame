using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    private bool doCutVolumeInHalf;

    AudioSource audio;

	// Use this for initialization
	void Start ()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!doCutVolumeInHalf)
        {
            audio.volume = CurrentData.gameData.volume; 
        }else
        {
            audio.volume = (CurrentData.gameData.volume/2);
        }
    }
}
