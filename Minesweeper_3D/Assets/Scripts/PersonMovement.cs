using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		bool stepForward = Input.GetKeyDown (KeyCode.W);
		bool turnLeft = Input.GetKeyDown (KeyCode.A);
		bool turnRight = Input.GetKeyDown (KeyCode.D);

		if (stepForward) {
			print("step");
			iTween.MoveAdd(gameObject, new Vector3(0f, 0f, -1f), 10f);
		}
		if (turnLeft) {
			print ("left");
			iTween.RotateBy(gameObject, iTween.Hash("y", 0.25f, "time", 10f));
		}
		if (turnRight) {
			print ("right");
			iTween.RotateBy(gameObject, iTween.Hash("y", -0.25f, "time", 10f));
		}
	}
}
