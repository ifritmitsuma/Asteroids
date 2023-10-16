using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using AssemblyCSharp;

public class StartGame : MonoBehaviour {

	private int _interval = 500;

	private double _lastTimestamp;

	private GameObject _eventsObject;

	private bool shown = true;

	// Use this for initialization
	void Start () {
		_lastTimestamp = DateTime.Now.TimeOfDay.TotalMilliseconds;
		_eventsObject = GameObject.FindGameObjectWithTag ("eventsObject");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.Space)) {
			ExecuteEvents.Execute<IEventHandler>(_eventsObject, null, (x,y)=>x.newGame());
			gameObject.SetActive (false);
		}

	}

	void FixedUpdate () {
		double stamp = DateTime.Now.TimeOfDay.TotalMilliseconds;
		if (stamp - _lastTimestamp > _interval) {
			_lastTimestamp = stamp;
			gameObject.transform.localScale = shown ? new Vector2 (0, 0) : new Vector2 (1, 1);
			shown = !shown;
		}

	}
}
