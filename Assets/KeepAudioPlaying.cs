using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAudioPlaying : MonoBehaviour {
	
	private AudioSource audioSource;
	//This whole script just makes sure the audio is playing
	//during the whole game
	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
