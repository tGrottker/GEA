using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {

	public GameObject plane;
	private Vector3 position;
	private Vector3 view;
	private GameGrid grid;

	// Use this for initialization
	void Start () {
		position = gameObject.transform.position;
		view = gameObject.transform.forward.normalized;
		grid = plane.GetComponent <GameGrid>();
	}
	
	// Update is called once per frame
	void Update () {
		bool stepForward = Input.GetKeyDown (KeyCode.W);
		bool turnLeft = Input.GetKeyDown (KeyCode.A);
		bool turnRight = Input.GetKeyDown (KeyCode.D);
		bool checkField = Input.GetMouseButtonDown (0);
		bool flagField = Input.GetMouseButtonDown (1);

		if (stepForward) {
			position = position + view;
			iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 1f, "orienttopath", false, "lookahead", 0f, "easetype", "easeInOutQuad"));
		}
		if (turnLeft) {
			Vector3 viewn = -gameObject.transform.right.normalized;
			position = position + (view + viewn) / 2;
			view = viewn;
			Vector3 looktarget = position + view;
			iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 1.5f, "orienttopath", false, "lookahead", 0f, "looktarget", looktarget, "easetype", "easeInOutQuad"));
		}
		if (turnRight) {
			Vector3 viewn = gameObject.transform.right.normalized;
			position = position + (view + viewn) / 2;
			view = viewn;
			Vector3 looktarget = position + view;
			iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 1.5f, "orienttopath", false, "lookahead", 0f, "looktarget", looktarget, "easetype", "easeInOutQuad"));
		}
		if (checkField) {
			int x = Mathf.FloorToInt(position.x);
			int z = Mathf.FloorToInt(position.z);
			int element = grid.getGameGridAtPosition(x, z);
			// if lid exists at pos (x,z)
			if (element != 9) {
				
			} else {
				// BOOOOOM!!!
			}
		}
		if (flagField) {
				
		}
	}
}
