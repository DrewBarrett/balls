using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
	public GameObject launcher;
	float defaultScale;
	Vector2 touchOrigin = Vector2.zero;
	// Use this for initialization
	void Start () {
		defaultScale = launcher.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.touchCount > 0 ) {
			var touch = Input.GetTouch (0);

			Vector2 touchEnd;
			if (touch.phase == TouchPhase.Began) {
				launcher.SetActive (true);
				touchOrigin = touch.position;
				//Debug.Log ("Touch started at " + touchOrigin.x + " " + touchOrigin.y );
			} else if (touch.phase == TouchPhase.Ended) {
				touchEnd = touch.position;
				Vector3 temp = Camera.main.ScreenToWorldPoint (touchEnd);
				temp.z = 10; // or whatever
				launcher.SetActive(false);
				//transform.position = temp;
			} else {
				// We are dragging
				Vector3 start = Camera.main.ScreenToWorldPoint (touchOrigin);
				Vector3 curr = Camera.main.ScreenToWorldPoint (touch.position);
				//Debug.Log (start);
				curr.z = 0;
				Debug.DrawLine (start, curr);
				var angle = Vector3.Angle (start, curr);
				Debug.DrawRay (Vector3.zero, -1 * (curr - start));

				//Vector3 temp = launcher.transform.localScale;
				//temp.y = defaultScale * (Vector3.Distance(curr, start) * .1f);
				//launcher.transform.localScale = temp;
				Debug.Log (angle);
			}
		}
	}
}
