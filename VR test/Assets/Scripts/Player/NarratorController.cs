using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NarratorController : MonoBehaviour
{

    private AudioSource voice;
    public List<string> playing = new List<string>();

    // Use this for initialization
    void Start()
    {
        voice = GetComponent<AudioSource>();
        StartSpeaking("part1");
    }


    // Update is called once per frame
    void Update()
    {
        ClearCurrentlyPlaying();
    }
    public void StartSpeaking(string _clip)
    {
        print(_clip);
        playing.Add(_clip);
        voice.clip = Resources.Load(_clip) as AudioClip;
        voice.Play(44100);

        if (!voice.isPlaying)
        {
            playing.Add(_clip);
        }
    }
    void ClearCurrentlyPlaying()
    {
        if (!voice.isPlaying && playing.Count >= 1)
        {
            //Checks if the voice has stoped and then clears the currentplaying array
            foreach (string _clip in playing)
            {
                playing.Remove(_clip);
            }
        }
    }
}
