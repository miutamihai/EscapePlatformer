using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
	public GameObject explosion;
    private List<string> destroyables;

	private void EliminateObject(GameObject gameobject, Collider2D collision){
		GameObject e = Instantiate(gameobject) as GameObject;
		e.transform.position = collision.transform.position;
		Destroy(collision.gameObject);
	}

    void Start()
    {
        destroyables = new List<string>();
        destroyables.Add("Coin");
        destroyables.Add("HeavyBandit");
        destroyables.Add("LightBandit");
        destroyables.Add("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(destroyables.Exists(x => x == collision.name) || destroyables.Exists(x => x == collision.tag))
        {
            Debug.Log("Target Destroyed");
            EliminateObject(explosion, collision);
        }
    }
}
