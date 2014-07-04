using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeight = 170;
	public bool paused = false;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		Time.timeScale = 1;
	}
	
	void OnGUI() {
		if (paused) {
			GUI.BeginGroup(new Rect(((Screen.width/2) - (groupWidth/2)), ((Screen.height/2) - (groupHeight/2)), groupWidth, groupHeight));
			if (GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), "Restart Game")) {
				print("Restarting game");
				Application.LoadLevel("Main_Scene");
			}
			if (GUI.Button(new Rect(0, 60, buttonWidth, buttonHeight), "Back to Mainmenu")) {
				print("Exiting game and going to main menu");
				Application.LoadLevel("Main_Menu");
			}
			if (GUI.Button(new Rect(0, 120, buttonWidth, buttonHeight), "Exit Game")) {
				Application.Quit();
			}
			GUI.EndGroup();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			paused = togglePause();
		}
	}
	
	private bool togglePause() {
		if (Time.timeScale == 0) {
			// unpause
			Screen.lockCursor = true;
			Time.timeScale = 1;
			return false;
		} else {
			// pause
			Screen.lockCursor = false;
			Time.timeScale = 0;
			return true;
		}
	}
	
}
