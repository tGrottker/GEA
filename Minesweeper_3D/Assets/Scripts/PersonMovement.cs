using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {

	private Vector3 position;
	private Vector3 forward;

	// Use this for initialization
	void Start () {
		position = gameObject.transform.position;
		forward = gameObject.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		bool stepForward = Input.GetKeyDown (KeyCode.W);
		bool turnLeft = Input.GetKeyDown (KeyCode.A);
		bool turnRight = Input.GetKeyDown (KeyCode.D);

		if (stepForward) {
			position = position + forward.normalized;
			iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 3f, "orienttopath", true, "lookahead", 0));
			//iTween.MoveAdd(gameObject, new Vector3(0f, 0f, -1f), 10f);
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
