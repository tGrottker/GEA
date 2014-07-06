using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour
{
	public GameObject plane;
	public GameObject flagPrefab;
	public GameObject flagSprite;
	public GameObject explosion;
	public GameObject smileyBad;

	private Vector3 position;
	private Vector3 view;
	private GameGrid grid;
	private bool readyForMovement;
	private float nextMove;
	private PauseMenu pauseMenu;
	private bool paused;
	private MouseLook mouseLook;


	// Use this for initialization
	void Start () {
		position = gameObject.transform.position;
		view = gameObject.transform.forward.normalized;
		grid = plane.GetComponent <GameGrid> ();
		nextMove = 0;
		pauseMenu = GameObject.FindWithTag("MainCamera").GetComponent<PauseMenu> ();
		mouseLook = GameObject.FindWithTag("MainCamera").GetComponent<MouseLook> ();
	}
	// Update is called once per frame
	void Update () {
		bool stepForward = Input.GetKeyDown (KeyCode.W);
		bool stepBack = Input.GetKeyDown (KeyCode.S);
		bool turnLeft = Input.GetKeyDown (KeyCode.A);
		bool turnRight = Input.GetKeyDown (KeyCode.D);
		bool checkField = Input.GetMouseButtonDown (0);
		bool flagField = Input.GetMouseButtonDown (1);
	
		if (pauseMenu.paused) {
			mouseLook.enabled = false;
			return;
		}
		if (!mouseLook.enabled) {
			mouseLook.enabled = true;
		}
		if (nextMove < Time.time) {
			if (stepForward) {
				nextMove = nextMove + 1.2f;
				position = position + view;
				iTween.MoveTo (gameObject, iTween.Hash ("position", position, "time", 1f, "orienttopath", false, "lookahead", 0f, "easetype", "easeInOutQuad"));
			} else if (stepBack) {
				nextMove = nextMove + 1.2f;
				position = position - view;
				iTween.MoveTo (gameObject, iTween.Hash ("position", position, "time", 1f, "orienttopath", false, "lookahead", 0f, "easetype", "easeInOutQuad"));
			} else if (turnLeft) {
				nextMove = nextMove + 1.7f;
				Vector3 viewn = -gameObject.transform.right.normalized;
				position = position + (view + viewn) / 2;
				view = viewn;
				Vector3 looktarget = position + 100000 * view;
				iTween.MoveTo (gameObject, iTween.Hash ("position", position, "time", 1.5f, "orienttopath", false, "lookahead", 0f, /*"looktarget", looktarget,*/"easetype", "easeInOutQuad"));
				iTween.LookTo (gameObject, iTween.Hash ("looktarget", looktarget, "time", 1.5f));
			} else if (turnRight) {
				nextMove = nextMove + 1.7f;
				Vector3 viewn = gameObject.transform.right.normalized;
				position = position + (view + viewn) / 2;
				view = viewn;
				Vector3 looktarget = position + 100000 * view;
				iTween.MoveTo (gameObject, iTween.Hash ("position", position, "time", 1.5f, "orienttopath", false, "lookahead", 0f, /*"looktarget", looktarget,*/"easetype", "easeInOutQuad"));
				iTween.LookTo (gameObject, iTween.Hash ("looktarget", looktarget, "time", 1.5f));
			} else if (checkField) {
				nextMove = nextMove + 0.3f;
				Vector3 field = position + view / 2;
				int x = Mathf.FloorToInt (field.x);
				int z = Mathf.FloorToInt (field.z);
				grid.deleteLidAtPosition (x, z);
				int state = grid.getGameGridAtPosition (x, z);
				if (state == 9) {
					gameOver(x, z);
				}
				if (grid.isFinished ()) {
					print ("You won!");
				}
			} else if (flagField) {
				nextMove = nextMove + 0.3f;
				Vector3 field = position + view / 2;
				int x = Mathf.FloorToInt (field.x);
				int z = Mathf.FloorToInt (field.z);
				grid.toggleFlag(x, z);
			}
		}
	}
	public Vector3 getCurrentField () {
		Vector3 curPosition = position + view / 2;
		curPosition.x = Mathf.FloorToInt (curPosition.x);
		curPosition.z = Mathf.FloorToInt (curPosition.z);
		return curPosition;
	}
	private void gameOver(int x, int z){
		PersonMovement personMovement = GameObject.FindWithTag ("Player").GetComponent<PersonMovement>();
		personMovement.enabled = false;

		mouseLook.enabled = false;
		GameObject foundMine = grid.getMineAtPosition (x, z);
		GameObject explosionObject = Instantiate (explosion, new Vector3 (foundMine.transform.position.x , -1, foundMine.transform.position.z), explosion.transform.rotation) as GameObject;

		iTween.MoveTo(gameObject, iTween.Hash("position", position - view, "time", 1.0f, "rotation", gameObject.transform.rotation));
		iTween.RotateTo (gameObject, new Vector3(-90.0f, 0.0f, 0), 1.0f);
		pauseMenu.paused = true;

		GameObject smileyBadObject = Instantiate (smileyBad, new Vector3(4.5f, 4.5f, 4.5f), smileyBad.transform.rotation) as GameObject;
		smileyBadObject.transform.parent = GameObject.FindWithTag ("MinimapCam").GetComponent<Transform> ();
	}
}
