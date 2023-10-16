using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour {

	float top;
	float bottom;
	float left;
	float right;

	GameObject clone = null;

	List<string> side = new List<string>();

	void Start() {
		top = 5f;
		bottom = -top;
		right = 11.7f;
		left = -right;

	}

	void OnTriggerExit2D(Collider2D other) {

		if (other.gameObject.tag.Equals ("bullet")) {
			Destroy (other.gameObject);
			return;
		}

		if (clone == null || clone == other.gameObject) {
			return;
		}

		bool killClone = false;

		if (side.Contains ("top")) {
			killClone = other.gameObject.transform.position.y < top;
			side.Remove ("top");
		}
		if (side.Contains ("bottom")) {
			killClone = other.gameObject.transform.position.y > bottom;
			side.Remove ("bottom");
		}
		if (side.Contains ("right")) {
			killClone = other.gameObject.transform.position.x < right;
			side.Remove ("right");
		}
		if (side.Contains ("left")) {
			killClone = other.gameObject.transform.position.x > left;
			side.Remove ("left");
		}

		if (killClone) {
            Debug.Log("Killing clone");
			Destroy (clone);
		} else {
            Debug.Log("Killing original");
			clone.name = other.gameObject.name;
			Destroy (other.gameObject);
		}
		clone = null;

	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag.Equals ("bullet")) {
			Destroy (other.gameObject);
			return;
		}

        if(other.gameObject == clone)
        {
            return;
        }

		if (clone == null) {
            clone = Instantiate(other.gameObject);
        }

		Vector2 transformPoint = other.gameObject.transform.position;

		float height = other.gameObject.transform.lossyScale.y * 10;

		float ctop = Mathf.Abs (top - transformPoint.y);
		float cbottom = Mathf.Abs (bottom - transformPoint.y);
		float cright = Mathf.Abs (right - transformPoint.x);
		float cleft = Mathf.Abs (left - transformPoint.x);

		if ( ctop < cbottom && ((ctop < cright && ctop < cleft) && !side.Contains("top"))) {
            Debug.Log("Hit top barrier");
            transformPoint.Set(clone.transform.position.x, bottom - (height / 2));
			side.Add("top");
		} else if (cbottom < ctop && ((cbottom < cright && cbottom < cleft) && !side.Contains("bottom"))) {// && cbottom < cright && cbottom < cleft) {
            Debug.Log("Hit bottom barrier");
            transformPoint.Set (clone.transform.position.x, top + (height / 2));
			side.Add("bottom");
		}

		if (cright < cleft && ((cright < ctop && cright < cbottom) && !side.Contains("right"))) {
            Debug.Log("Hit right barrier");
            transformPoint.Set(left - (height / 2), clone.transform.position.y);
			side.Add("right");
		} else if (cleft < cright && ((cleft < ctop && cleft < cbottom) && !side.Contains("left"))) {
            Debug.Log("Hit left barrier");
            transformPoint.Set(right + (height / 2), clone.transform.position.y);
			side.Add("left");
		}

		clone.transform.position = transformPoint;
		clone.GetComponent<Rigidbody2D> ().velocity = other.gameObject.GetComponent<Rigidbody2D> ().velocity;
		//Debug.Log ("Ship X:" + clone.transform.position.x + " Y:" + clone.transform.position.y + " Velocity:" + other.gameObject.GetComponent<Rigidbody2D> ().velocity);

	}

	void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.tag.Equals ("bullet")) {
			Destroy (other.gameObject);
			return;
		}
	}


}
