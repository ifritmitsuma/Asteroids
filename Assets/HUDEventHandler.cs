using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class HUDEventHandler : MonoBehaviour, IEventHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void newGame() {
		Array.Find(Resources.FindObjectsOfTypeAll<GameObject>(), isShip).SetActive(true);
		foreach(Transform tr in GameObject.Find("HUD").transform) {
			if (!tr.gameObject.name.EndsWith ("Overlay")) {
				tr.gameObject.SetActive (true);
			}
		}
	}

	public void shoot() {

	}

	public void shotAsteroid() {

	}

	public void hit() {

	}

	public void gameOver() {
		Array.Find(Resources.FindObjectsOfTypeAll<GameObject>(), isShip).SetActive(false);
	}

	public bool isShip(GameObject obj) {
		return obj.name.Equals ("Ship");
	}
}
