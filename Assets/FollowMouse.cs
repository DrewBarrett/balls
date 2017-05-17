using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.touchCount > 0 ) {
			var touch = Input.GetTouch (0);
			Vector2 touchOrigin;
			Vector2 touchEnd;
			if (touch.phase == TouchPhase.Began) {
				touchOrigin = touch.position;
			}
			if (touch.phase == TouchPhase.Ended) {
				touchEnd = touch.position;
				Vector3 temp = Camera.main.ScreenToWorldPoint(touchEnd);
				temp.z = 10; // or whatever
				transform.position = temp;
			}
		}
	}
}