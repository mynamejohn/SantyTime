using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioSource AS;
    public AudioClip AC;
    // Use this for initialization
    private void Awake()
    {
    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void PlayMusic()
    {
        AS.clip = AC;
        AS.Play();
    }
}
