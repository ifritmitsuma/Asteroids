using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ShipController : MonoBehaviour
	{

		int lives = 3;

		GameObject bullet;

		float zDegrees = 0;

		// Use this for initialization
		void Start () {
		}

		// Update is called once per frame
		void Update () {

			if (Input.GetKey (KeyCode.RightArrow)) {
				gameObject.transform.Rotate (new Vector3 (0, 0, -1));
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				gameObject.transform.Rotate (new Vector3 (0, 0, 1));
			}

			zDegrees = gameObject.transform.rotation.eulerAngles.z;

			if (Input.GetKey (KeyCode.UpArrow)) {
				gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2((float) -Math.Sin(Math.PI * zDegrees / 180) / 30, (float) Math.Cos(Math.PI * zDegrees / 180) / 30), ForceMode2D.Impulse);
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				GameObject obj = Instantiate (GameObject.FindGameObjectWithTag ("bullet"));
				obj.transform.position = new Vector3((float)-Math.Sin (Math.PI * zDegrees / 180) + transform.position.x, (float)Math.Cos (Math.PI * zDegrees / 180) + transform.position.y, transform.position.z);
				if (obj.transform.position.y < -5f || obj.transform.position.y > 5f ||
				    obj.transform.position.x < -11.7f || obj.transform.position.x > 11.7f) {
					Destroy (obj);
				} else {
					obj.GetComponent<Rigidbody2D> ().AddForce (new Vector2 ((float)-Math.Sin (Math.PI * zDegrees / 180) * 10, (float)Math.Cos (Math.PI * zDegrees / 180)) * 10, ForceMode2D.Impulse);
				}
			}
		}
	
	}
}

