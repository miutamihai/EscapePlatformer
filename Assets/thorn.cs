using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thorn : MonoBehaviour {

	// Use this for initialization
	public GameObject explosion;
	private GameObject player;
	private void RestartScene()
	{
		//This function reloads the scene
		Debug.Log("restarting scene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void KillPlayer()
	{
		//Here the player object is destroyed and the explosion animation
		//is instantiated at the player's former position
		GameObject e = Instantiate(explosion) as GameObject;
		e.transform.position = player.transform.position;
		Destroy(player);
		//This invoke function calls another function after a 2 sec delay 
		Invoke("RestartScene", 2);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("thorns hit");
		//This checks whether the thorns have been hit 
		if (collision.name == "Body")
		   KillPlayer();
	}
	void Start ()
	{
		//This function is called when a thorn object is instantiated
		//It instantiates the player object to be destroyed later
		//by the KillPlayer function
		player = GameObject.Find("Knight");
	}
}
