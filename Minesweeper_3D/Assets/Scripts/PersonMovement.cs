using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour
{

		public GameObject plane;
		public GameObject flagPrefab;
		private Vector3 position;
		private Vector3 view;
		private GameGrid grid;
		private bool readyForMovement;
		private float nextMove;
		private PauseMenu pauseMenu;	

		// Use this for initialization
		void Start ()
		{
				position = gameObject.transform.position;
				view = gameObject.transform.forward.normalized;
				grid = plane.GetComponent <GameGrid> ();
				nextMove = 0;
				pauseMenu = GameObject.Find ("Main Camera").GetComponent<PauseMenu> ();
		}

		// Update is called once per frame
		void Update ()
		{
		
				bool stepForward = Input.GetKeyDown (KeyCode.W);
				bool stepBack = Input.GetKeyDown (KeyCode.S);
				bool turnLeft = Input.GetKeyDown (KeyCode.A);
				bool turnRight = Input.GetKeyDown (KeyCode.D);
				bool checkField = Input.GetMouseButtonDown (0);
				bool flagField = Input.GetMouseButtonDown (1);
				
				if (pauseMenu.paused) {
						return;
				}

				float currentTime = Time.time;
				if (nextMove < currentTime) {
						if (stepForward) {
								nextMove = currentTime + 1.2f;
								position = position + view;
								iTween.MoveTo (gameObject, iTween.Hash ("position", position, "time", 1f, "orienttopath", false, "lookahead", 0f, "easetype", "easeInOutQuad"));
						} else if (stepBack) {
								nextMove = currentTime + 1.2f;
								position = position - view;
								iTween.MoveTo (gameObject, iTween.Hash ("position", position, "time", 1f, "orienttopath", false, "lookahead", 0f, "easetype", "easeInOutQuad"));
						} else if (turnLeft) {
								nextMove = currentTime + 1.7f;
								Vector3 viewn = -gameObject.transform.right.normalized;
								position = position + (view + viewn) / 2;
								view = viewn;
								Vector3 looktarget = position + 100000 * view;
								iTween.MoveTo (gameObject, iTween.Hash ("position", position, "time", 1.5f, "orienttopath", false, "lookahead", 0f, /*"looktarget", looktarget,*/"easetype", "easeInOutQuad"));
								iTween.LookTo (gameObject, iTween.Hash ("looktarget", looktarget, "time", 1.5f));
						} else if (turnRight) {
								nextMove = currentTime + 1.7f;
								Vector3 viewn = gameObject.transform.right.normalized;
								position = position + (view + viewn) / 2;
								view = viewn;
								Vector3 looktarget = position + 100000 * view;
								iTween.MoveTo (gameObject, iTween.Hash ("position", position, "time", 1.5f, "orienttopath", false, "lookahead", 0f, /*"looktarget", looktarget,*/"easetype", "easeInOutQuad"));
								iTween.LookTo (gameObject, iTween.Hash ("looktarget", looktarget, "time", 1.5f));
						} else if (checkField) {
								nextMove = currentTime + 0.3f;
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
								nextMove = currentTime + 0.3f;
								Vector3 field = position + view / 2;
								int x = Mathf.FloorToInt (field.x);
								int z = Mathf.FloorToInt (field.z);
								grid.toggleFlagAtPosition (x, z);								
						}
				}

		}

		public Vector3 getCurrentField ()
		{
				Vector3 curPosition = position + view / 2;
				curPosition.x = Mathf.FloorToInt (curPosition.x);
				curPosition.z = Mathf.FloorToInt (curPosition.z);
				return curPosition;
		}
}
