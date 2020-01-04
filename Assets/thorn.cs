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
		Debug.Log("restarting scene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void KillPlayer()
	{
		GameObject e = Instantiate(explosion) as GameObject;
		e.transform.position = player.transform.position;
		Destroy(player);
		Invoke("RestartScene", 2);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("thorns hit");
		if (collision.name == "Body")
		   KillPlayer();
	}
	void Start ()
	{
		player = GameObject.Find("Knight");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
