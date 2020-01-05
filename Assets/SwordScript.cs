using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordScript : MonoBehaviour {
	public GameObject explosion;
    private List<string> destroyables;

    void LoadWinScene()
    {
        //This function loads the 'You Win' scene
        SceneManager.LoadScene("WinScene");
    }

	private void EliminateObject(GameObject gameobject, Collider2D collision){
        //This function destroys game objects, be they the coin or enemies
		GameObject e = Instantiate(gameobject) as GameObject;
		e.transform.position = collision.transform.position;
		Destroy(collision.gameObject);
        //Here we check if the coin has been destroyed, in which
        //case, the 'You Win' screen is loaded
        if (collision.name == "Coin")
            Invoke("LoadWinScene", 2);
	}

    void Start()
    {
        //Here we create a list of game objects that can be destroyed
        destroyables = new List<string>();
        destroyables.Add("Coin");
        destroyables.Add("HeavyBandit");
        destroyables.Add("LightBandit");
        //Notice that later we check for both the name and the 
        //tag of the game object, just to be on the safe side
        destroyables.Add("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        //If the object's tag or name is in the destroyables list,
        //we call the EliminateObject function
        if(destroyables.Exists(x => x == collision.name) || destroyables.Exists(x => x == collision.tag))
        {
            Debug.Log("Target Destroyed");
            EliminateObject(explosion, collision);
        }
    }
}
