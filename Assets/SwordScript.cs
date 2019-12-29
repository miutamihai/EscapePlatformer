using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
	public GameObject explosion;
	public GameObject bandit;

	private void EliminateObject(GameObject gameobject, Collider2D collision){
		GameObject e = Instantiate(gameobject) as GameObject;
		e.transform.position = collision.transform.position;
		Destroy(collision.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision){
		switch(collision.name){
			case "Coin":
					Debug.Log("Coin Collected");
					EliminateObject(explosion, collision);
					break;
			//case "HeavyBandit":
				//	Debug.Log("Enemy Killed");
				//	EliminateObject(explosion, collision);
				//break;
		}
	}
}
