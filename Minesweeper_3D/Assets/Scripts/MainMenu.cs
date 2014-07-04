using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeight = 170;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = false;
	}
	
	void OnGUI () {
		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight));
		if (GUI.Button (new Rect (0, 0, buttonWidth, buttonHeight), "Start Game")) {
			Application.LoadLevel ("Main_Scene");
		}
		if (GUI.Button (new Rect (0, 60, buttonWidth, buttonHeight), "Credits")) {
			Application.LoadLevel ("Credits");
		}
		if (GUI.Button (new Rect (0, 120, buttonWidth, buttonHeight), "Exit Game")) {
			Application.Quit ();
		}
		GUI.EndGroup ();
	}
}
