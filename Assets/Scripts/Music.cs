using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    public AudioClip music;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source.loop = true;
        source.clip = music;
        source.Play();
	}

}
