using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {

	Text flashingText;
 
	void Start(){
		//get the Text component
		flashingText = GetComponent<Text>();
		//Call coroutine BlinkText on Start
		StartCoroutine(BlinkText());
	}

	private void Update()
	{
		//This function loads the main scene on pressing any key
		if (Input.anyKey)
		{
			SceneManager.LoadScene("MainScene");
		}
	}

	//function to blink the text
	public IEnumerator BlinkText(){
		//blink it forever. You can set a terminating condition depending upon your requirement
		while(true){
			//set the Text's text to blank
			flashingText.text= "";
			//display blank text for 0.5 seconds
			yield return new WaitForSeconds(.5f);
			//display “Press any key to Play” for the next 0.5 seconds
			flashingText.text= "Press any key to Play";
			yield return new WaitForSeconds(.5f);
		}
	}
 
}

