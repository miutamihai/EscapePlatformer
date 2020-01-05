using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	private void Update()
	{
		if (Input.anyKey)
		{
			//This only loads the main scene from the 'You Won' screen
			SceneManager.LoadScene("MainScene");
		}
	}
}
