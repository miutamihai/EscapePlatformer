using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAudioPlaying : MonoBehaviour {
	
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
