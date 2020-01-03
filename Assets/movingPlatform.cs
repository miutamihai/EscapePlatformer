using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

    private bool movingRight = true;
    public float variation = 2.5f;
    private float originalVariation;
    public float speed = 10;

	// Use this for initialization
	void Start () {
        originalVariation = variation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((movingRight ? Vector2.right : Vector2.left) * (speed * Time.deltaTime));
        variation -= Time.deltaTime;
        if (variation <= 0)
        {
            movingRight = !movingRight;
            variation = originalVariation;
        }
    }
}
