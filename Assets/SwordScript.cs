using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
	public GameObject explosion;

	private void OnTriggerEnter2D(Collider2D collision){
		if(collision.name == "Coin")
		{
			Debug.Log("am luat moneda");
			GameObject e = Instantiate(explosion) as GameObject;
			e.transform.position = collision.transform.position;
			Destroy(collision.gameObject);
		}
	}
}
