using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {

	public GameObject plane;
	public GameObject flagPrefab;
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
		bool stepBack = Input.GetKeyDown (KeyCode.S);
		bool turnLeft = Input.GetKeyDown (KeyCode.A);
		bool turnRight = Input.GetKeyDown (KeyCode.D);
		bool checkField = Input.GetMouseButtonDown (0);
		bool flagField = Input.GetMouseButtonDown (1);

		if (stepForward) {
			position = position + view;
			iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 1f, "orienttopath", false, "lookahead", 0f, "easetype", "easeInOutQuad"));
		} else if (stepBack) {
			position = position - view;
			iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 1f, "orienttopath", false, "lookahead", 0f, "easetype", "easeInOutQuad"));
		} else if (turnLeft) {
			Vector3 viewn = -gameObject.transform.right.normalized;
			position = position + (view + viewn) / 2;
			view = viewn;
			Vector3 looktarget = position + view;
			iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 1.5f, "orienttopath", false, "lookahead", 0f, "looktarget", looktarget, "easetype", "easeInOutQuad"));
		} else if (turnRight) {
			Vector3 viewn = gameObject.transform.right.normalized;
			position = position + (view + viewn) / 2;
			view = viewn;
			Vector3 looktarget = position + view;
			iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 1.5f, "orienttopath", false, "lookahead", 0f, "looktarget", looktarget, "easetype", "easeInOutQuad"));
		} else if (checkField) {
			Vector3 field = position + view / 2;
			int x = Mathf.FloorToInt(field.x);
			int z = Mathf.FloorToInt(field.z);
			grid.deleteLidAtPosition(x, z);

		} else if (flagField) {
			Vector3 field = position + view / 2;
			int x = Mathf.FloorToInt(field.x);
			int z = Mathf.FloorToInt(field.z);
			bool flagable = grid.hasLidAtPosition(x, z);
			GameObject flagObject = Instantiate(flagPrefab, new Vector3(field.x, 0.1f, field.z), Quaternion.identity) as GameObject;
			flagObject.transform.parent = GameObject.FindWithTag("GameArea").GetComponent<Transform>();
			//flagObject.animation.Play();
		}
	}
}
