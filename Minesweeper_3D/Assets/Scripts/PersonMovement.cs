﻿using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
	public GameObject plane;
	public GameObject flagPrefab;
	private Vector3 position;
	private Vector3 view;
	private GameGrid grid;
	private bool readyForMovement;
	private float nextMove;
	private PauseMenu pauseMenu;	

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
		public GameObject flagSp		public GameObject flagSprite;
>>>>>>> created and added FlagSprite for Minimap
=======
		public GameObject flagSprite;
>>>>>>> created and added FlagSprite for Minimap
		public GameObject plane;
		public GameObject flagPrefab;
		private Vector3 position;
		private Vector3 view;
		private GameGrid grid;
		private bool readyForMovement;
		private float nextMove;
		private PauseMenu pauseMenu;	
=======
=======
>>>>>>> 371594027ca4048f53fa5f076fd7afbbc9f35b32
	public GameObject plane;
	public GameObject flagPrefab;
	public GameObject flagSprite;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 371594027ca4048f53fa5f076fd7afbbc9f35b32
	private Vector3 position;
	private Vector3 view;
	private GameGrid grid;
	private bool readyForMovement;
	private float nextMove;
<<<<<<< HEAD
	private bool paused;
>>>>>>> created and added FlagSprite for Minimap
=======
>>>>>>> created and added FlagSprite for Minimap
=======

<<<<<<< HEAD
=======
>>>>>>> created and added FlagSprite for Minimap
		// Use this for initialization
		void Start ()
		{
				position = gameObject.transform.position;
				view = gameObject.transform.forward.normalized;
				grid = plane.GetComponent <GameGrid> ();
				nextMove = 0;
				pauseMenu = GameObject.Find ("Main Camera").GetComponent<PauseMenu> ();
		}
>>>>>>> created and added FlagSprite for Minimap

	// Use this for initialization
	void Start () {
		position = gameObject.transform.position;
		view = gameObject.transform.forward.normalized;
		grid = plane.GetComponent <GameGrid> ();
		nextMove = 0;
		pauseMenu = GameObject.FindWithTag("MainCamera").GetComponent<PauseMenu> ();
	}

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
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
										print ("BOOOM!!!");
										print ("You lost!");
								}
<<<<<<< HEAD
<<<<<<< HEAD
								if (grid.isFinished ()) {
										print ("You won!");
								}
						} else if (flagField) {
							nextMove = nextMove + 0.3f;
							Vector3 field = position + view / 2;
							int x = Mathf.FloorToInt (field.x);
							int z = Mathf.FloorToInt (field.z);
							grid.toggleFlagAtPosition (x, z);
							bool flagable = grid.hasLidAtPosition (x, z);
							if(flagable){
								GameObject flagObject = Instantiate (flagPrefab, new Vector3 (field.x, 0.1f, field.z), Quaternion.identity) as GameObject;
								flagObject.transform.parent = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
								//flagObject.animation.Play();
						}
<<<<<<< HEAD
=======
=======
>>>>>>> added new Flag model; added new Mine model, added lights to flag, added animation to flag
		if (!paused) {
=======
=======
	// Use this for initialization
	void Start () {
		position = gameObject.transform.position;
		view = gameObject.transform.forward.normalized;
		grid = plane.GetComponent <GameGrid> ();
		nextMove = 0;
		pauseMenu = GameObject.FindWithTag("MainCamera").GetComponent<PauseMenu> ();
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
						return;
				}

		if (!paused) {
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
						print ("BOOOM!!!");
						print ("You lost!");
					}
					if (grid.isFinished ()) {
						print ("You won!");
					}
				} else if (flagField) {
					nextMove = nextMove + 0.3f;
					Vector3 field = position + view / 2;
					int x = Mathf.FloorToInt (field.x);
					int z = Mathf.FloorToInt (field.z);
					bool flagable = grid.hasLidAtPosition (x, z);
>>>>>>> resolved errors
	// Update is called once per frame
	void Update () {
		bool stepForward = Input.GetKeyDown (KeyCode.W);
		bool stepBack = Input.GetKeyDown (KeyCode.S);
		bool turnLeft = Input.GetKeyDown (KeyCode.A);
		bool turnRight = Input.GetKeyDown (KeyCode.D);
		bool checkField = Input.GetMouseButtonDown (0);
		bool flagField = Input.GetMouseButtonDown (1);
	
		/*if (pauseMenu.paused) {
			return;
<<<<<<< HEAD
<<<<<<< HEAD
=======
								if (grid.isFinished ()) {										print ("You won!");								}						} else if (flagField) {								nextMove = nextMove + 0.3f;								Vector3 field = position + view / 2;								int x = Mathf.FloorToInt (field.x);								int z = Mathf.FloorToInt (field.z);								grid.toggleFlagAtPosition (nt = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
=======
								if (grid.isFinished ()) {										
									print ("You won!");
								nextMove = nextMove + 0.3f;
								Vector3 field = position + view / 2;
								int x = Mathf.FloorToInt (field.x);
								int z = Mathf.FloorToInt (field.z);
								grid.toggleFlagAtPosition (nt = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
>>>>>>> created and added FlagSprite for Minimap
					if(flagable){
						GameObject flagObject = Instantiate (flagPrefab, new Vector3 (field.x, 0.1f, field.z), Quaternion.identity) as GameObject;
=======
		}else{
=======
		}else{*/
>>>>>>> - added trees
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
						print ("BOOOM!!!");
						print ("You lost!");
					}
					if (grid.isFinished ()) {
						print ("You won!");
					}
				} else if (flagField) {
					nextMove = nextMove + 0.3f;
					Vector3 field = position + view / 2;
					int x = Mathf.FloorToInt (field.x);
					int z = Mathf.FloorToInt (field.z);
					bool flagable = grid.hasLidAtPosition (x, z);
					if (flagable) {
						GameObject flagObject = Instantiate (flagPrefab, new Vector3 (field.x, 0.5f, field.z), Quaternion.identity) as GameObject;
>>>>>>> resolved errors
						flagObject.transform.parent = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
					}
				}
<<<<<<< HEAD

>>>>>>> created and added FlagSprite for Minimap
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
						print ("BOOOM!!!");
						print ("You lost!");
					}
					if (grid.isFinished ()) {
						print ("You won!");
					}
				} else if (flagField) {
					nextMove = nextMove + 0.3f;
					Vector3 field = position + view / 2;
					int x = Mathf.FloorToInt (field.x);
					int z = Mathf.FloorToInt (field.z);
					bool flagable = grid.hasLidAtPosition (x, z);
<<<<<<< HEAD
					if(flagable){
<<<<<<< HEAD
						GameObject flagObject = Instantiate (flagPrefab, new Vector3 (field.x, 0.5f, field.z), Quaternion.identity) as GameObject;
						flagObject.transform.parent = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
=======
>>>>>>> created and added FlagSprite for Minimap
=======
						GameObject flagObject = Instantiate (flagPrefab, new Vector3 (field.x, 0.1f, field.z), Quaternion.identity) as GameObject;
=======
					if (flagable) {
						GameObject flagObject = Instantiate (flagPrefab, new Vector3 (field.x, 0.5f, field.z), Quaternion.identity) as GameObject;
						flagObject.transform.parent = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
>>>>>>> resolved errors
						flagObject.transform.parent = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
>>>>>>> added new Flag model; added new Mine model, added lights to flag, added animation to flag

						GameObject minimapFlag = Instantiate (flagSprite, new Vector3 (field.x, 0.2f, field.z), flagSprite.transform.rotation) as GameObject;
						minimapFlag.transform.parent = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
					}
<<<<<<< HEAD
					//flagObject.animation.Play();
>>>>>>> created and added FlagSprite for Minimap
=======
>>>>>>> created and added FlagSprite for Minimap
				}
			}
		//}
<<<<<<< HEAD
	}

=======
			}
		}
=======
>>>>>>> - added trees
	}

>>>>>>> resolved errors
=======
	private PauseMenu pauseMenu;
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
					print ("BOOOM!!!");
					print ("You lost!");
				}
				if (grid.isFinished ()) {
					print ("You won!");
				}
			} else if (flagField) {
				nextMove = nextMove + 0.3f;
				Vector3 field = position + view / 2;
				int x = Mathf.FloorToInt (field.x);
				int z = Mathf.FloorToInt (field.z);
				bool flagable = grid.hasLidAtPosition (x, z);
				if (flagable) {
					GameObject flagObject = Instantiate (flagPrefab, new Vector3 (field.x, 0.5f, field.z), Quaternion.identity) as GameObject;
					flagObject.transform.parent = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
				}
			}
		}
	}
>>>>>>> 371594027ca4048f53fa5f076fd7afbbc9f35b32
	public Vector3 getCurrentField () {
		Vector3 curPosition = position + view / 2;
		curPosition.x = Mathf.FloorToInt (curPosition.x);
		curPosition.z = Mathf.FloorToInt (curPosition.z);
		return curPosition;
	}
}
