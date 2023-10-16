using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, -0.1f), Space.Self);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy (collision.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag.Equals ("bullet")) {
			Destroy (gameObject);
			Destroy (collider.gameObject);
		}
	}
}
