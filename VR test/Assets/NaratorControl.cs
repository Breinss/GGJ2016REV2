using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NaratorControl : MonoBehaviour {
	
	private AudioSource voice;
	public List<string> playing = new List<string>();




	// Use this for initialization
	void Start () {
		voice = GetComponent<AudioSource> ();
		StartSpeaking ("power_up");
	}

	
	// Update is called once per frame
	void Update () {
		if (!voice.isPlaying) {
			StartSpeaking ("power_up");

		}
	}
	void StartSpeaking(string _clip){
		playing.Add (_clip);
		voice.clip = Resources.Load (_clip) as AudioClip;
		voice.Play (44100);
	}
}
