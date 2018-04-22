using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour {

    AudioSource audio;
    CharacterController cc;

	// Use this for initialization
      
	void Start () {
        audio = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(cc.isGrounded && cc.velocity.magnitude > 2f && audio.isPlaying)
        {
            print("HELLLLLLLOOOOOOOOOOOOOOO");
            audio.volume = Random.Range(0.8f, 1f);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
	}
}
